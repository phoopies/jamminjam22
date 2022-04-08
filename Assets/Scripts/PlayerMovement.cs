using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float movementSpeed = 4f;

	[SerializeField]
	private float jumpStrength = 6.25f;

	[SerializeField]
	private float gravity = -9.81f;

	[SerializeField]
	private float airControl = 0.25f;

	private Vector3 velocity;

	private CharacterController characterController;

	private void Awake()
	{
		characterController = GetComponent<CharacterController>();
	}

	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		float horInput = Input.GetAxis("Horizontal");

		if (characterController.isGrounded)
        {
			velocity.y = -1;

			velocity.x = horInput * movementSpeed;
			//velocity += 

			if (Input.GetButtonDown("Jump"))
			{
				Jump();
			}
		}
		else
        {
			velocity.y += gravity * Time.deltaTime;

			velocity.x = horInput * movementSpeed /** airControl*/;
		}

		characterController.Move(velocity * Time.deltaTime);
	}


	void Jump()
	{
		velocity.y = jumpStrength;
	}

	void Move()
	{

	}
}
