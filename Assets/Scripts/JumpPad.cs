using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class JumpPad : Activatable
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
			playerMovement.Jump(strength);
			CameraShake.Shake(.2f, .3f);
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
