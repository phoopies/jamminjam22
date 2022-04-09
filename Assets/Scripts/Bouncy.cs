using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        PlayerMovement playerMovement = collision.transform.GetComponent<PlayerMovement>();
        if (playerMovement)
        {
            Debug.Log("Bounce");
            playerMovement.BounceBack();
        }
    }
}
