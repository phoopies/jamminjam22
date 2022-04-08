using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class MovingPlatform : MonoBehaviour
{
	private Vector3 startPosition;

	[SerializeField]
	private GameObject target;

	[SerializeField]
	private float speed = 1f;

	[SerializeField]
	private float wait = 1f;

	float waitTimer;

	private Vector3 endPosition;

	private Vector3 targetPosition;

	// Start is called before the first frame update
	void Start()
	{
		startPosition = transform.position;
		endPosition = target.transform.position;
		targetPosition = endPosition;
		Destroy(target);
	}

	// Update is called once per frame
	void Update()
	{
		if (waitTimer > 0f)
        {
			waitTimer -= Time.deltaTime;
        }
		else
        {
			if (Vector3.Distance(transform.position, targetPosition) <= 0.01f)
			{
				if (targetPosition == startPosition)
				{
					targetPosition = endPosition;
				}
				else
				{
					targetPosition = startPosition;
				}
				waitTimer = wait;
			}
			transform.Translate((targetPosition - transform.position).normalized * speed * Time.deltaTime);
		}
	}

    private void OnTriggerEnter(Collider other)
    {
		PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement)
        {
			Debug.Log("MovingPlatform");
			playerMovement.gameObject.transform.SetParent(transform, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
		PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
		if (playerMovement)
		{
			playerMovement.gameObject.transform.SetParent(null);
		}
	}
}
