using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static int deathCounter;

	[SerializeField]
	private GameObject deathParticle;

	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void Die()
	{
		// TODO polish
		CameraShake.Shake(.3f, .6f);
		deathCounter++;
		StartCoroutine(Died());
		GetComponent<MeshRenderer>().enabled = false;
		Instantiate(deathParticle, transform.position, transform.rotation);
	}

	private IEnumerator Died()
	{
		yield return new WaitForSeconds(1f);
		GameManager.ReloadScene();
	}
}
