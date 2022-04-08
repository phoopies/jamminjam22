using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class Collectible : MonoBehaviour
{
	private AudioSource audioSource;

	[SerializeField]
	private GameObject deathParticle;

	// Start is called before the first frame update
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<PlayerMovement>())
		{
			Debug.Log("Collectible");

			GameManager.AddCollectible();

			audioSource.Play();

			Instantiate(deathParticle, transform.position, transform.rotation);

			Destroy(gameObject);
		}
	}
}
