using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore2Script : MonoBehaviour
{
    //public Text Score2;
    public Text HighScore;
    public LogicScript logic;
    private bool clear = false;
    private bool newBest = false;

    [SerializeField] private AudioSource NewBestSoundEffect;
    public GameObject NewBestText;
    public GameObject NewBest2Text;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //HighScore.text = PlayerPrefs.GetInt("ExtremeExtremeHighScore").ToString();
        if (PlayerPrefs.GetInt(ScenesManager.playerprefs, 0) >= PlayerPrefs.GetInt(ScenesManager.player2prefs, 0))
        {
            HighScore.text = PlayerPrefs.GetInt(ScenesManager.playerprefs, 0).ToString();
            Debug.Log("Using first pref"+ PlayerPrefs.GetInt(ScenesManager.playerprefs, 0));
        }
        else if (PlayerPrefs.GetInt(ScenesManager.playerprefs, 0) < PlayerPrefs.GetInt(ScenesManager.player2prefs, 0))
        {
            HighScore.text = PlayerPrefs.GetInt(ScenesManager.player2prefs, 0).ToString();
            Debug.Log("Using second pref"+ PlayerPrefs.GetInt(ScenesManager.player2prefs, 0));
        }
            
    }

    public IEnumerator Wait()
    {
        NewBestText.SetActive(true);
        yield return new WaitForSeconds(ScenesManager.WaitForSecond);
        NewBestText.SetActive(false);
    }

    public IEnumerator Wait2()
    {
        NewBest2Text.SetActive(true);
        yield return new WaitForSeconds(ScenesManager.WaitForSecond);
        NewBest2Text.SetActive(false);
    }


    public void GetScore()
    {
        int number = logic.playerScore;
        int number2 = logic.player2Score;

        if (number > PlayerPrefs.GetInt(ScenesManager.playerprefs, 0) && number > PlayerPrefs.GetInt(ScenesManager.player2prefs, 0))
        {
            PlayerPrefs.SetInt(ScenesManager.playerprefs, number);
            HighScore.text = number.ToString();
            if (PlayerPrefs.GetInt(ScenesManager.playerprefs, 0) == 1)
            {
                newBest = true;
            }
            if (newBest == false)
            {
                StartCoroutine(Wait());
                NewBestSoundEffect.Play();
                newBest = true;
            }
        }
        else if (number2 > PlayerPrefs.GetInt(ScenesManager.playerprefs, 0) && number2 > PlayerPrefs.GetInt(ScenesManager.player2prefs, 0))
        {
            PlayerPrefs.SetInt(ScenesManager.player2prefs, number2);
            HighScore.text = number2.ToString();
            if (PlayerPrefs.GetInt(ScenesManager.player2prefs, 0) == 1)
            {
                newBest = true;
            }
            if (newBest == false)
            {
                StartCoroutine(Wait2());
                NewBestSoundEffect.Play();
                newBest = true;
            }
        }
    }



    public void Reset()
    {
        PlayerPrefs.DeleteKey(ScenesManager.playerprefs);
        PlayerPrefs.DeleteKey(ScenesManager.player2prefs);
        Debug.Log("playerprefs"+ PlayerPrefs.GetInt(ScenesManager.playerprefs, 0));
        Debug.Log("player2prefs" + PlayerPrefs.GetInt(ScenesManager.player2prefs, 0));
        HighScore.text = "0";
        clear = true;
    }



    private void Update()
    {
        int number = logic.playerScore;
        int number2 = logic.player2Score;
        
        if (clear == false)
        {
            GetScore();
        }
    }
}
