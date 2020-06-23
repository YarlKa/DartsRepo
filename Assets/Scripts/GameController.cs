using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameUI))]
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField]
    private int dartsCount;

    [Header("Darts Spawning")]
    [SerializeField]
    private Vector2 dartsSpawnPosition;
    [SerializeField]
    private GameObject dartsObject;

    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        Instance = this;
        GameUI = GetComponent<GameUI>();
    }

    private void Start()
    {
        
        GameUI.SetInitialDisplayDartsCount(dartsCount);
        SpawnDarts();
    }

    public void OnSuccessfulDartsHit()
    {
        
        if (dartsCount > 0)
        {
            
            SpawnDarts();
        }
        else
        {
            
            StartGameOverSecuence(true);
        }
    }

    private void SpawnDarts()
    {
        
        dartsCount--;
        Instantiate(dartsObject, dartsSpawnPosition, Quaternion.identity);
    }

    public void StartGameOverSecuence(bool win)
    {
        
        StartCoroutine("GameOverSecuenceCorutline", win);
    }

    private IEnumerator GameOverSecuenceCorutline(bool win)
    {
        
        if(win)
        {
                       yield return new WaitForSecondsRealtime(0.3f);
            RestartGame();
        }
        else
        {
            
            GameUI.ShowRestartButton();
        }
    }
    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}

