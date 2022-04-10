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

    [SerializeField]
    float closeEnoughOffset = .1f;

    [SerializeField]
    private bool isSingleShot;

    private bool used;

    [SerializeField]
    private uint minWeight = 1;

    [SerializeField]
    float isDownTreshold = 0.1f;

    private Transform child;

    void Start()
    {
        child = transform.GetChild(0);

        originY = child.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (used && isSingleShot) return;

        float currentY = child.localPosition.y;
        Vector3 pos = child.localPosition;
        
        if (isDown && child.localPosition.y > isDownTreshold)
        {
            isDown = false;
            pos.y = originY;
            child.localPosition = pos;
            activatable.Deactivate();
        }
        else if (!isDown && child.localPosition.y <= isDownTreshold)
        {
            if (used && isSingleShot) return;
            Debug.Log("Do something I'm giving up on you!");
            used = true;
            isDown = true;
            activatable.Activate();
        }

        if (stuffOnMe < minWeight && currentY < originY - closeEnoughOffset)
        {
            child.localPosition += Vector3.up * upSpeed * Time.deltaTime;
        }
        else if (stuffOnMe >= minWeight)
        {
            if (child.localPosition.y < originY - .15f)
            {

            }
            else
            {
                child.localPosition += Vector3.down * downSpeed * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        stuffOnMe++;
    }

    private void OnTriggerExit(Collider collision)
    {
        stuffOnMe--;
        //isDown = stuffOnMe >= minWeight;
        //if (!isDown && !isSingleShot)
        //{
         //activatable.Deactivate();
        //}
    }
}
