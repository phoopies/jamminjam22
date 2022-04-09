using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int deathCounter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        // TODO polish
        CameraShake.Shake(.3f, .6f);
        deathCounter++;
        GameManager.ReloadScene();
    }
}
