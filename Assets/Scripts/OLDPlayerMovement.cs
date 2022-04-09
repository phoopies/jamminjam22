using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class OLDPlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float movementSpeed = 4f;

	[SerializeField]
	private float jumpStrength = 4.25f;

	[SerializeField]
	private float gravity = -9.81f;

	[SerializeField]
	private float airControl = 0.25f;

	private bool inAir;

	[SerializeField]
	private GameObject groundHitPs;

	private Vector3 velocity;

	private CharacterController characterController;

	private Rotator rotator;

	private void Awake()
	{
		characterController = GetComponent<CharacterController>();
	}

	void Start()
	{
		rotator = FindObjectOfType<Rotator>();
	}

	// Update is called once per frame
	void Update()
	{
		float horInput = Input.GetAxisRaw("Horizontal");

		velocity.x = (rotator.GetTargetRight() * horInput * movementSpeed).x;
		velocity.z = (rotator.GetTargetRight() * horInput * movementSpeed).z;

		if (characterController.isGrounded)
        {
			if (inAir)
            {
				Landed();
			}
			velocity.y = -1;

			//velocity.x = horInput * movementSpeed;
			

			if (Input.GetButtonDown("Jump"))
			{
				Jump();
			}
		}
		else
        {
			velocity.y += gravity * Time.deltaTime;

			//velocity.x = horInput * movementSpeed /** airControl*/;
		}

		characterController.Move(velocity * Time.deltaTime);

	}

	void Landed()
    {
		inAir = false;
		Instantiate(groundHitPs, transform.position + new Vector3(0f, -0.5f, 0f), Quaternion.Euler(-90, 0, 0));
		CameraShake.Shake(0.1f, 0.13f);
	}

	void Jump()
	{
		inAir = true;
		velocity.y = jumpStrength;
	}

	void Move()
	{

	}
}
