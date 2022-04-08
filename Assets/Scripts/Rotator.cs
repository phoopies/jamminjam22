using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float rotateSpeed = 10f;
    private Quaternion targetQuaternion = Quaternion.identity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, rotateSpeed * Time.deltaTime);
        if (transform.rotation != targetQuaternion) return;
        transform.rotation = targetQuaternion;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            targetQuaternion = transform.rotation * Quaternion.Euler(0, 90f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            targetQuaternion = transform.rotation * Quaternion.Euler(0, -90f, 0);
        }
    }
}
