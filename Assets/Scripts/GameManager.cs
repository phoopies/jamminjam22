using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Animator))]
public class GameManager : MonoBehaviour
{
    public static int collectibles;

    private static GameObject player;

    private Animator animator;

    private static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadNextScene()
    {
        instance.StartCoroutine(instance.LoadScene());
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void AddCollectible()
    {
        collectibles++;

        foreach (var t in player.GetComponentsInChildren<TMP_Text>())
        {
            t.SetText(collectibles.ToString());
        }
    }

    IEnumerator LoadScene()
    {
        if (animator.isActiveAndEnabled)
            animator.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }
}
