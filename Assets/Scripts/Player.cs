using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
	public static int deathCounter;

	[SerializeField]
	private GameObject deathParticle;

	void Start()
	{
		foreach (var t in GetComponentsInChildren<TMP_Text>())
		{
			t.SetText("");
		}
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
		GameManager.collectiblesInRound = 0;
		StartCoroutine(Died());
		GetComponent<MeshRenderer>().enabled = false;
		foreach (var t in GetComponentsInChildren<TMP_Text>())
        {
			t.enabled = false;
        }
		Instantiate(deathParticle, transform.position, transform.rotation);
	}

	private IEnumerator Died()
	{
		yield return new WaitForSeconds(1f);
		GameManager.ReloadScene();
	}
}
