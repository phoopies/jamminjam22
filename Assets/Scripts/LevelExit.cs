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
		RenderSettings.ambientIntensity = Random.Range(0.99f, 1.01f);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<PlayerMovement>())
		{
			source.pitch = Random.Range(0.85f, 1.15f);
			source.Play();
			GameManager.LoadNextScene();
		}
	}
}
