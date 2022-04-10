using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int collectibles;

    public static int deathCounter;

    public static int collectiblesInRound;

    private static GameObject player;

    private Animator animator;

    public static GameManager instance;


    private void Awake()
    {
        instance = this;

        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        collectiblesInRound = collectibles;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadNextScene()
    {
        instance.StartCoroutine(instance.LoadScene());
    }

    public static IEnumerator DelayedReloadScene()
    {
        yield return new WaitForSeconds(1.33f);
        ReloadScene();
    }

    public static void ReloadScene()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        if (current == 0 || current == SceneManager.sceneCountInBuildSettings - 1) return;
        collectibles = collectiblesInRound;
        SceneManager.LoadScene(current);
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
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
