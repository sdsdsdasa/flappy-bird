using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Device;

public class ColdDown1Script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float coolDownTime = 7;
    public float nextFireTime = 0;
    public Transform BirdPosition;
    private Boolean used = false;

    private void Update()
    {
        if (Time.time > nextFireTime)
        {
            used = false;
            if (Input.GetKeyDown(KeyCode.Q) && used == false)
            {
                used = true;
                Debug.Log("ability used, cooldown started");
                transform.position = BirdPosition.position;
                myRigidbody.velocity = Vector2.right;
                nextFireTime = Time.time + coolDownTime;

            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = BirdPosition.position;
                myRigidbody.velocity = Vector2.right;
            }

        }
    }

    private void resetPosition()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position = new Vector2(0, 80);
        myRigidbody.velocity = new Vector2(0, 0);
    }
}

