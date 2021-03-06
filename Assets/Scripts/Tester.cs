using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField]
    private KeyCode loadNextScene = KeyCode.N;

    [SerializeField]
    private KeyCode camShakeActivator = KeyCode.M;

    [SerializeField]
    private float camShakeDuration = .25f;

    [SerializeField]
    private float camShakeAmount = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(camShakeActivator))
        {
            //CameraShake.Shake(camShakeDuration, camShakeAmount);
        }
        else if (Input.GetKeyDown(loadNextScene))
        {
            //GameManager.LoadNextScene();
        }
        else if (Input.GetButtonDown("Reset"))
        {
            Player player = FindObjectOfType<Player>();
            if (player) player.Die();
        }
    }
}
