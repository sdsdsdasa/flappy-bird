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
            Debug.Log("ready");
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
        //if (Time.time > FinishTime)
        //{
        //    Hide();
        //}
    }


    //public float cooldownDuration = 5.0f; // Adjust this to your desired cooldown time
    //private float cooldownTimer = 0.0f;
    //public Rigidbody2D myRigidbody;

    //public bool OnScreen = false;


    //public void Hide()
    //{
    //    transform.rotation = new Quaternion(0, 0, 0, 0);
    //    transform.position = new Vector2(0, 80);
    //}


    //public void Show()
    //{
        
    //    transform.position = BirdPosition.position;
    //    FinishTime = Time.time + 3;

    //}

    //void Update()
    //{
    //    if (cooldownTimer > 0)
    //    {
    //        cooldownTimer -= cooldownDuration * Time.deltaTime;
    //        if (cooldownTimer <= 0)
    //        {
    //            // Cooldown is over, re-enable the object
    //            cooldownTimer = 0;
    //            Show();
    //            Debug.Log("true");
    //        }
    //    }
    //    if (Input.GetKeyDown(KeyCode.M) == true)
    //    {
    //        StartCooldown();
    //    }

    //    if (Input.GetKeyDown(KeyCode.N) == true)
    //    {
    //        Show();
    //        Debug.Log("true");
    //    }

    //    // Other script code...
    //}

    //public void StartCooldown()
    //{
    //    cooldownTimer = cooldownDuration;
    //    Hide();
    //    Debug.Log("false");
    //}


}

