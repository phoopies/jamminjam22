using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;

    [SerializeField]
    private float jumpHeight = 2f;

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
        velocity.y -= Time.deltaTime * 9.81f;
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        float horInput = Input.GetAxis("Horizontal");
        velocity.x = horInput * movementSpeed;
        characterController.Move(velocity * Time.deltaTime);
    }


    void Jump()
    {
        velocity.y = jumpHeight;
    }

    void Move()
    {

    }
}
