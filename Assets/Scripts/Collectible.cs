using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Collectible : MonoBehaviour
{
	[SerializeField]
	private AudioClip clip;

	[SerializeField]
	private GameObject deathParticle;

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<PlayerMovement>())
		{
			Debug.Log("Collectible");

			GameManager.AddCollectible();

			GameObject g = new GameObject();
			GameObject inst = Instantiate(g);

			AudioSource s = inst.AddComponent<AudioSource>();
			s.playOnAwake = false;
			s.volume = .5f;
			s.clip = clip;
			s.Play();
			Destroy(s, 3f);


			Instantiate(deathParticle, transform.position, transform.rotation);

			Destroy(gameObject);
		}
	}
}
