using UnityEngine;
using UnityEngine.UI;

public class DiceScript : MonoBehaviour
{
    public Text Score;
    public Text HighScore;
    //public LogicScript logic;


    [ContextMenu("Increase Score")]

    private void Start()
    {
        //logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    //public void RollScore()
    //{
    //    int number = Random.Range(1, 7);
    //    Score.text = number.ToString();

    //    if (number > PlayerPrefs.GetInt("HighScore", 0))
    //    {
    //        PlayerPrefs.SetInt("HighScore", number);
    //        HighScore.text = number.ToString();
    //    }
    //}

    public void GetScore()
    {
        int number = 2;
        Score.text = number.ToString();

        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);
            HighScore.text = number.ToString();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        HighScore.text = "0";
    }

    //private void Update()
    //{
    //    GetScore();
    //}
}
