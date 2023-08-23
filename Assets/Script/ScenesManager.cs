using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static float gravity;
    public static float birdStrength;
    public static float pipeSpeed;
    public static float pipeSpawnRate;
    public static string playerprefs;
    public static string player2prefs;
    public static float WaitForSecond;
    public static string mode = "solo";
    public static string level = "Easy";

    public void SoloMode()
    {
        mode = "solo";
    }

    public void DuoMode()
    {
        mode = "duo";
    }

    public void GoDifficultiesScene()
    {
        SceneManager.LoadScene("DifficultiesScene");
    }

    public void GoModeScene()
    {
        SceneManager.LoadScene("PlayerModeScene");
    }

    public void quitToMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void quitToPlayerMode()
    {
        SceneManager.LoadScene("PlayerModeScene");
    }

    public void quitToDiff()
    {
        SceneManager.LoadScene("DifficultiesScene");
    }

    public void easyMode()
    {
        gravity = 5;
        birdStrength = 20;
        pipeSpeed = 7;
        pipeSpawnRate = 3;
        playerprefs = "HighScore";
        player2prefs = "HighScore2";
        WaitForSecond = 5;
        level = "Easy";
        CheckPlayerMode();
    }
    

    public void hardMode()
    {
        gravity = 5;
        birdStrength = 21;
        pipeSpeed = 13;
        pipeSpawnRate = 1.7f;
        playerprefs = "HardHighScore";
        player2prefs = "HardHighScore2";
        WaitForSecond = 2;
        level = "Hard";
        CheckPlayerMode();
    }

    public void ExtremeMode()
    {
        gravity = 7;
        birdStrength = 28;
        pipeSpeed = 19;
        pipeSpawnRate = 1.3f;
        playerprefs = "ExtremeHighScore";
        player2prefs = "ExtremeHighScore2";
        WaitForSecond = 2;
        level = "Extreme";
        CheckPlayerMode();
    }

    public void ExtremeExtremeMode()
    {
        gravity = 5;
        birdStrength = 28;
        pipeSpeed = 19;
        pipeSpawnRate = 1.3f;
        playerprefs = "ExtremeExtremeHighScore";
        player2prefs = "ExtremeExtremeHighScore2";
        WaitForSecond = 2;
        level = "ExtremeExtreme";
        CheckPlayerMode();
    }


    private void CheckPlayerMode()
    {
        if (mode == "solo")
        {
            SceneManager.LoadScene("SoloScene");
        }
        else if (mode == "duo")
        {
            SceneManager.LoadScene("DuoScene");
        }
    }

}
