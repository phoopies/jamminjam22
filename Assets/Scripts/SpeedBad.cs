using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpeedBad : Activatable
{
	[SerializeField]
	private float strength = 12f;

	private ParticleSystem ps;

	private BoxCollider boxCollider;


	// Start is called before the first frame update
	void Start()
	{
		ps = GetComponentInChildren<ParticleSystem>();
		boxCollider = GetComponent<BoxCollider>();
		if (isActive)
		{
			ps.Play();
			boxCollider.enabled = true;

		}
		else
		{
			boxCollider.enabled = false;
			ps.Stop();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!isActive) return;
		PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
		if (playerMovement)
		{
			Vector3 vel = transform.right * strength;
			playerMovement.SpeedBoost(vel);
			playerMovement.Jump(1.25f); // mini jump
			CameraShake.Shake(.1f, .15f);
		}
	}

	public override void Activate()
	{
		base.Activate();
		boxCollider.enabled = true;
		ps.Play();
	}

	public override void Deactivate()
	{
		base.Deactivate();
		boxCollider.enabled = false;
		ps.Stop();
	}
}
