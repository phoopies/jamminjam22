using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseBlocker : MonoBehaviour
{
    [SerializeField]
    private string[] msgs;

    [SerializeField]
    private GameObject message;

    [SerializeField]
    private Canvas canvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            Vector3 mousePos = Input.mousePosition;
            Quaternion randomQuaternion = Quaternion.Euler(0, 0, Random.Range(-30, 30));
            GameObject inst = Instantiate(message, mousePos, randomQuaternion, canvas.transform);
            string randomMsg = msgs[Mathf.FloorToInt(Random.value * msgs.Length)];
            inst.GetComponent<TMP_Text>().SetText(randomMsg);
            Destroy(inst, 3.0f);
        }
    }
}
