using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public static BackgroundMusicScript backroundMusic;

    void Awake()
    {
        if (backroundMusic == null)
        {
            backroundMusic = this;
            DontDestroyOnLoad(backroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
