using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
	[SerializeField]
	private GameObject breakParticle;

	[SerializeField]
	private AudioClip clip;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.other.CompareTag("Player"))
		{
			Instantiate(breakParticle, transform.position, transform.rotation);

			GameObject g = new GameObject();
			GameObject inst = Instantiate(g);

			AudioSource s = inst.AddComponent<AudioSource>();
			s.playOnAwake = false;
			s.volume = .5f;
			s.clip = clip;
			s.pitch = Random.Range(0.85f, 1.15f);
			s.Play();
			Destroy(s, 3f);

			Destroy(gameObject);
		}
	}
}
