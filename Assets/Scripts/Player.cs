using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

	[SerializeField]
	private GameObject deathParticle;

	void Start()
	{
		foreach (var t in GetComponentsInChildren<TMP_Text>())
		{
			t.SetText(GameManager.collectibles > 0 ? GameManager.collectibles.ToString() : "");
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void Die()
	{
		CameraShake.Shake(.3f, .6f);
		GameManager.deathCounter++;
		GameManager.instance.StartCoroutine(GameManager.DelayedReloadScene());
		Instantiate(deathParticle, transform.position, transform.rotation);
		Destroy(gameObject);
	}

}
