using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    private Activatable activatable;

    uint stuffOnMe;
    float originY;

    [SerializeField]
    private float downSpeed = 1f;

    [SerializeField]
    private float upSpeed = 1f;

    bool isDown;

    float downY;

    [SerializeField]
    float closeEnoughOffset = .1f;

    bool hasBeenUp = true;

    [SerializeField]
    private bool isSingleShot;

    private bool used;

    private uint minWeight = 1;

    [SerializeField]
    float isDownTreshold = 0.1f;

    void Start()
    {
        originY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (used && isSingleShot) return;

        float currentY = transform.localPosition.y;
        Vector3 pos = transform.localPosition;
        
        if (isDown && transform.localPosition.y > isDownTreshold)
        {
            isDown = false;
            pos.y = originY;
            transform.localPosition = pos;
            activatable.Deactivate();
        }
        else if (!isDown && transform.localPosition.y <= isDownTreshold)
        {
            if (used && isSingleShot) return;
            Debug.Log("Do something I'm giving up on you!");
            used = true;
            isDown = true;
            activatable.Activate();
        }

        if (stuffOnMe < minWeight && currentY < originY - closeEnoughOffset)
        {
            transform.localPosition += Vector3.up * upSpeed * Time.deltaTime;
        }
        else if (stuffOnMe >= minWeight)
        {
            transform.localPosition += Vector3.down * downSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        stuffOnMe++;
    }

    private void OnCollisionExit(Collision collision)
    {
        stuffOnMe--;
        //isDown = stuffOnMe >= minWeight;
        //if (!isDown && !isSingleShot)
        //{
         //activatable.Deactivate();
        //}
    }
}
