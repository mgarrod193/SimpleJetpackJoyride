using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    //reference to Hud elemtents
    [SerializeField] TextMeshProUGUI ScoreText;

    //references to extra spawners
    [SerializeField] GameObject ExtraSpanwer1;
    [SerializeField] GameObject ExtraSpanwer2;
    [SerializeField] GameObject ExtraSpanwer3;
    [SerializeField] GameObject ExtraBarrellSpawner1;


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

    public void updateScoreText()
    {
        ScoreText.text = "Score: " + score.ToString();
    }

    //updates scores by an amount after a certain dealy while player is alive
    //score increases by larger amounts the longer the game lasts
    private IEnumerator UpdateScore()
    {
        while (isPlayerAlive)
        {
            yield return new WaitForSeconds(scoreUpdateTimer);
            score += updateScoreAmount;
            updateScoreText();
            if (score == 150)
            {
                updateScoreAmount = 2;
                ExtraSpanwer1.SetActive(true);
            }
            if (score == 400)
            {
                updateScoreAmount = 3;
                ExtraSpanwer2.SetActive(true);
            }
            if (score == 900)
            {
                updateScoreAmount = 4;
                ExtraBarrellSpawner1.SetActive(true);
            }
            if (score == 1500)
            {
                updateScoreAmount += 5;
                ExtraSpanwer3.SetActive(true);
            }
        }
    }

    //called to restart scene a 3 seconds after player dies.
    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
