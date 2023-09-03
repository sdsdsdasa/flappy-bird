using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int player2Score;
    public Text scoreText;
    public Text score2Text;
    public Text GameOverText;
    public GameObject gameOverScreen;
    public BirdScript Bird1;
    public BirdScript2 Bird2;
    private bool playWinSound = true;

    [SerializeField] private AudioSource WinSoundEffect;

    private void Start()
    {
        Bird1 = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        if (ScenesManager.mode == "duo")
        {
            Bird2 = GameObject.FindGameObjectWithTag("Bird2").GetComponent<BirdScript2>();
        }
    }

        [ContextMenu("Increase Score")]
    public void addScore(int ScoreToAdd)
        //increase player score
    {
        playerScore = playerScore + ScoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void addScore2(int ScoreToAdd)
    //increase player score
    {
        player2Score = player2Score + ScoreToAdd;
        score2Text.text = player2Score.ToString();
    }

    public void restartGame()
        // providing function that restart the game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
        // set game over screen active
    {
        gameOverScreen.SetActive(true);
        if (ScenesManager.mode == "solo")
        {
            GameOverText.text = "Game Over";
            GameOverText.color = new Color32(0,66,255,248);
        }
        else if (ScenesManager.mode == "duo")
        {
            if (playerScore > player2Score)
            {
                GameOverText.text = "Red Won!";
                GameOverText.color = new Color32(174,56,29,248);
            }
            else if (playerScore < player2Score)
            {
                GameOverText.text = "Yellow Won!";
                GameOverText.color = new Color32(248,188,82,248);
            }
            else if (playerScore == player2Score)
            {
                GameOverText.text = "Draw";
                GameOverText.color = new Color32(98,120,97,248);
            }
            
        }

    }

    private void Update()
    {
        if (ScenesManager.mode == "solo")
        {
            if (Bird1.birdIsAlive == false)
            {
                gameOver();
            }
        }
        else if (ScenesManager.mode == "duo")
        {
            if (Bird1.birdIsAlive == false && Bird2.bird2IsAlive == false)
            {
                gameOver();
                if (playWinSound == true && GameOverText.text != "Draw")
                {
                    WinSoundEffect.Play();
                    playWinSound = false;
                }
            }
        }
    }
}
