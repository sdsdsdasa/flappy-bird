using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingScript : MonoBehaviour
{
    public void scene2()
    {
        SceneManager.LoadScene("TestingScene2");
    }

    public void scene1()
    {
        SceneManager.LoadScene("TestingScene");
    }
}
