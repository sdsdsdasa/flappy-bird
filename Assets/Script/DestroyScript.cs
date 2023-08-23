using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    //public static DontDestroyScript instance;

    public void Start()
    {
        //Debug.Log(Object.FindObjectOfType<BackgroundMusicScript>().name);
    }

    public void DestroyStartMusic()
    {
        //Debug.Log(GameObject.Find("BackgoundMusic"));
        Destroy(GameObject.Find("BackgoundMusic"));
    }
    public void DestroyPlayMusic()
    {
        Destroy(GameObject.Find("Background Music Play"));
    }
}
