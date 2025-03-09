using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    //variables for player status
    private bool isPlayerAlive;

    //variables for managing score
    public int score;
    private static float scoreUpdateTimer = 0.5f;
    private int updateScoreAmount = 1;
    private Coroutine updateScore;

    //creates singleton of game manager
    void Awake()
    {
        instance = this;
    }

   //Called when game starts
    private void Start()
    {
        score = 0;
        isPlayerAlive = true;
        updateScore = StartCoroutine(UpdateScore());
    }

    //called when player dies
    public void setPlayerDead()
    {
        isPlayerAlive = false;
        print("player is dead");
        print(score);
        StartCoroutine(RestartScene());
    }

    //updates scores by an amount after a certain dealy while player is alive
    private IEnumerator UpdateScore()
    {
        while (isPlayerAlive)
        {
            yield return new WaitForSeconds(scoreUpdateTimer);
            score += updateScoreAmount;
        }
    }

    //called to restart scene a 3 seconds after player dies.
    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
