using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Renderer>().enabled = false;
        Destroy(this);
    }
}
