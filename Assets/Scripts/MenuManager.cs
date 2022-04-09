using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    private int nextLevelInt = 0;

    [SerializeField]
    private int quitInt = 2;

    private Rotator rotator;
    private void Start()
    {
        rotator = FindObjectOfType<Rotator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            int y = (int)rotator.transform.rotation.eulerAngles.y;
            if (y % 90 != 0) return;
            int rotation = Mathf.FloorToInt(y / 90) % 4;
            Debug.Log(rotation);
            if (rotation == nextLevelInt)
            {
                GameManager.LoadNextScene();
            }
            else if (rotation == quitInt)
            {
                GameManager.QuitGame();
            }
        }   
    }
}
