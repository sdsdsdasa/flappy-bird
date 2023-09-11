using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class ColdDown1Script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float coolDownTime = 7;
    public float nextFireTime = 0;
    public Transform BirdPosition;

    private void Update()
    {
        if (Time.time > nextFireTime)
        {
            //Bugs cannot display rocket correctly
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("ability used, cooldown started");
                transform.position = BirdPosition.position;
                nextFireTime = Time.time + coolDownTime;
                myRigidbody.velocity = Vector2.right;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = BirdPosition.position;
            }
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.position = new Vector2(0, 80);
            myRigidbody.velocity = new Vector2(0, 0);
        }
    }
}

