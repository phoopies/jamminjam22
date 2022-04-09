using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
	[SerializeField]
	private GameObject breakParticle;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.other.CompareTag("Player"))
		{
			Instantiate(breakParticle, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
