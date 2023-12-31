using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class ColdDownScript : MonoBehaviour
{
    public float coolDownTime = 7;
    public float nextFireTime = 0;
    public float FinishTime = 0;
    public Transform BirdPosition;

    private void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("ability used, cooldown started");
                nextFireTime = Time.time + coolDownTime;
                FinishTime = Time.time + 3;
            }
        }
        if (FinishTime > Time.time)
        {
            transform.position = BirdPosition.position;
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.position = new Vector2(0, 80);
        }
    }
}

