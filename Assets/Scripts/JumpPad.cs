using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class JumpPad : Activatable
{
	[SerializeField]
	private float strength = 12f;

	private ParticleSystem ps;

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
			playerMovement.Jump(strength);
			CameraShake.Shake(.2f, .3f);
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
		//ps.gameObject.SetActive(isActive);
	}
}
