using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider)), RequireComponent(typeof(AudioSource))]
public class LevelExit : MonoBehaviour
{
	private AudioSource source;
	// Start is called before the first frame update
	void Start()
	{
		source = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<PlayerMovement>())
		{
			source.Play();
			GameManager.LoadNextScene();
		}
	}
}
