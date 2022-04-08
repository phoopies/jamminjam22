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
        if (Input.GetButtonDown("RotateLeft"))
        {
            targetQuaternion = transform.rotation * Quaternion.Euler(0, 90f, 0);
            CameraShake.Shake(.2f, .7f);
        }
        else if (Input.GetButtonDown("RotateRight"))
        {
            targetQuaternion = transform.rotation * Quaternion.Euler(0, -90f, 0);
            CameraShake.Shake(.2f, .7f);
        }
    }

    public Vector3 GetTargetRight()
    {
        return targetQuaternion * Vector3.right;
    }
}
