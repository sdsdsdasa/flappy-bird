using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreScript : MonoBehaviour
{
    //public Text Score;
    public Text HighScore;
    public LogicScript logic;
    private bool clear = false;
    private bool newBest = false;

    [SerializeField] private AudioSource NewBestSoundEffect;
    public GameObject NewBestText;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //HighScore.text = PlayerPrefs.GetInt("ExtremeExtremeHighScore").ToString();
        HighScore.text = PlayerPrefs.GetInt(ScenesManager.playerprefs).ToString();
    }

    public IEnumerator WaitFive()
    {
        NewBestText.SetActive(true);
        yield return new WaitForSeconds(ScenesManager.WaitForSecond);
        NewBestText.SetActive(false);
    }


    public void GetScore()
    {
        int number = logic.playerScore;

        if (number > PlayerPrefs.GetInt(ScenesManager.playerprefs, 0))
        {
            PlayerPrefs.SetInt(ScenesManager.playerprefs, number);
            HighScore.text = number.ToString();
            if (PlayerPrefs.GetInt(ScenesManager.playerprefs, 0) == 1)
            {
                newBest = true;
            }
            if (newBest == false)
            {
                StartCoroutine(WaitFive());
                //ShowNewBest();
                NewBestSoundEffect.Play();
                newBest = true;
            }
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey(ScenesManager.playerprefs);
        HighScore.text = "0";
        clear = true;
    }



    private void Update()
    {
        int number = logic.playerScore;

        if (clear == false)
        {
            GetScore();
        }
    }
}
