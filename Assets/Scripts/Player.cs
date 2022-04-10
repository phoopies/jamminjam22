using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{

	[SerializeField]
	private GameObject deathParticle;

	[SerializeField]
	private AudioClip clip;
	private AudioSource source;
	void Start()
	{
		source = GetComponent<AudioSource>();
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
		GameObject g = new GameObject();
		GameObject inst = Instantiate(g);
		
		AudioSource s = inst.AddComponent<AudioSource>();
		s.playOnAwake = false;
		s.volume = 0.5f;
		s.clip = clip;
		s.pitch = Random.Range(0.85f, 1.15f);
		s.Play();
		Destroy(s, 3f);

		CameraShake.Shake(.3f, .6f);
		GameManager.deathCounter++;
		GameManager.instance.StartCoroutine(GameManager.DelayedReloadScene());
		Instantiate(deathParticle, transform.position, transform.rotation);
		Destroy(gameObject);
	}

}
