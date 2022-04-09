using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpeedBad : Activatable
{
	[SerializeField]
	private float strength = 12f;

	private ParticleSystem ps;

	[SerializeField]
	private bool toLeft;


	// Start is called before the first frame update
	void Start()
	{
		ps = GetComponentInChildren<ParticleSystem>();
		if (isActive)
		{
			ps.Play();
		}
		else
		{
			ps.Stop();
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if (!isActive) return;
		PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
		if (playerMovement)
		{
			//Vector3 vel =  (toLeft ? -1 : 1) * new Vector3(1,0,1) * strength;
			Vector3 vel = transform.right * strength;
			playerMovement.SpeedBoost(vel);
			playerMovement.Jump(1.25f); // mini jump
			CameraShake.Shake(.1f, .15f);
		}
	}

	public override void Activate()
	{
		base.Activate();
		ps.Play();
	}

	public override void Deactivate()
	{
		base.Deactivate();
		ps.Stop();
	}
}
