using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(Collider))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private bool movementEnabled = true;

	[SerializeField]
	private float movementSpeed = 4f;

	[SerializeField]
	private float jumpStrength = 4.25f;

	[SerializeField]
	private float gravity = -9.81f;

	[SerializeField]
	private float airControl = 0.25f;

	private bool inAir;

	private bool isGrounded;

	[SerializeField]
	private GameObject groundHitPs;

	[SerializeField]
	private float groundRayDistance = 0.2f;

	[SerializeField]
	private LayerMask groundMask;

	private Rigidbody rb;

	private float halfHeight;

	private float halfWidth;

	private MovingPlatform platform;


	private Rotator rotator;

	private float horInput;
	private bool jumpInput;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rotator = FindObjectOfType<Rotator>();

		Collider col = GetComponent<Collider>();
		halfHeight = col.bounds.extents.y;
		halfWidth = col.bounds.extents.x;
		Debug.LogFormat("halfHeight {0}", halfHeight);
	}

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (!movementEnabled) return;
		horInput = Input.GetAxisRaw("Horizontal");
		jumpInput = jumpInput || Input.GetButton("Jump");
	}

    private void FixedUpdate()
    {
		UpdateIsGrounded();

		Vector3 movement = new Vector3(1, 0, 1);

		movement.x = (rotator.GetTargetRight() * horInput * movementSpeed).x;
		movement.z = (rotator.GetTargetRight() * horInput * movementSpeed).z;

		if (isGrounded)
		{
			if (platform)
			{
				rb.velocity = platform.GetVelocity();
			}

			if (inAir)
			{
				Landed();
			}

			if ( jumpInput && !HitHead())
			{
				Jump();
			}
		}
		else
		{
			if (rb.velocity.y <= .1f)
            {
				Vector3 oldVel = rb.velocity;
				oldVel.y += gravity * Time.deltaTime * .7f;
				rb.velocity = oldVel;
            }
			if (HitHead())
			{
				Debug.Log("Hit head");
				rb.AddForce(Vector3.down * .5f);
				//CameraShake.Shake(0.1f, 0.1f);
			}

			movement.x *= airControl;
			movement.z *= airControl;
		}

		rb.MovePosition(transform.position + movement * Time.deltaTime);

		// NOMNOMONMO
		horInput = 0;
		jumpInput = false;
	}

	void UpdateIsGrounded()
	{
		Vector3 thatSmallOffset = Vector3.up * 0.05f;
		Vector3 corner1 = transform.position + new Vector3(1, -1, 1) * halfWidth + thatSmallOffset;
		Vector3 corner2 = transform.position + -1*Vector3.one * halfWidth + thatSmallOffset;
		Debug.DrawRay(corner1, Vector3.down * groundRayDistance, Color.red);
		Debug.DrawRay(corner2, Vector3.down * groundRayDistance, Color.red);
		isGrounded = Physics.Raycast(corner1, Vector3.down, groundRayDistance, groundMask)
			|| Physics.Raycast(corner2, Vector3.down, groundRayDistance, groundMask);
	}



	bool HitHead()
	{
		Debug.DrawRay(transform.position + Vector3.up * halfHeight, Vector3.up * groundRayDistance, Color.blue);
		return Physics.Raycast(transform.position + Vector3.up * halfHeight, Vector3.up, groundRayDistance, groundMask);
	}

	void Landed()
	{
		if (rb.velocity.y > -1f) return;
		Debug.Log(rb.velocity.y);
		// a value between 0 and .15
		float landingForce = -1*Statics.MapClamped(rb.velocity.y, -10f, -1f, -.25f, 0f);
		inAir = false;
		Instantiate(groundHitPs, transform.position + new Vector3(0f, -0.5f, 0f), Quaternion.Euler(-90, 0, 0));
		CameraShake.Shake(0.1f, landingForce);
	}

	void Jump()
    {
		Jump(jumpStrength);
    }

	public void Jump(float strength)
	{
		Debug.Log("JUMP");
		platform = null;
		inAir = true;
		Vector3 oldVel = rb.velocity;
		oldVel.y = 0;
		rb.velocity = oldVel;
		rb.AddForce(Vector3.up * strength, ForceMode.Impulse);
	}

	public void setPlatform(MovingPlatform aPlatform)
    {
		platform = aPlatform;
    }

	public void SpeedBoost(Vector3 vel)
    {
		//Vector3 modifiedVel = Vector3.Scale(vel, rotator.GetTargetRight());
		//Debug.Log(modifiedVel);
		rb.AddForce(vel, ForceMode.Impulse);
    }

	public void BounceBack()
    {
		rb.velocity *= -.95f;
    }
}
