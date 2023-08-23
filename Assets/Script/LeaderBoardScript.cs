using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardScript : MonoBehaviour
{
    public Text leaderboardText;

    void Start()
    {
        // Display leaderboard on start
        DisplayLeaderboard();
    }

    public void AddScore(int score)
    {
        // Get the current high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // If the new score is higher than the high score, update it
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }

        // Display leaderboard
        DisplayLeaderboard();
    }

    void DisplayLeaderboard()
    {
        // Get the high score and display it
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        leaderboardText.text = "High Score: " + highScore;
    }
}
