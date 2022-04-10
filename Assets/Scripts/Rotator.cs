using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float rotateSpeed = 10f;
    private Quaternion targetQuaternion = Quaternion.identity;

    [SerializeField]
    private GameObject RotatePs;

    private AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
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
            Rotated();
        }
        else if (Input.GetButtonDown("RotateRight"))
        {
            targetQuaternion = transform.rotation * Quaternion.Euler(0, -90f, 0);
            Rotated();
        }
    }

    public Vector3 GetTargetRight()
    {
        return targetQuaternion * Vector3.right;
    }

    void Rotated()
    {
        CameraShake.Shake(.2f, .7f);
        audioS.pitch = Random.Range(0.85f, 1.15f);
        audioS.Play();
        Instantiate(RotatePs);
    }
}
