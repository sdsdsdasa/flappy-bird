using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2Script : MonoBehaviour
{
    public BirdScript2 Bird2Status;
    public GameObject Bird2;
    public GameObject Weapon1;
    public float rotationSpeed = 1000.0f;

    void Start()
    {
        Bird2Status = GameObject.FindGameObjectWithTag("Bird2").GetComponent<BirdScript2>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Bird2.GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Weapon1.GetComponent<Collider2D>(), true);
    }



    private void Update()
    {
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.gameObject.tag == "Pipe")
        {
            Destroy(collision.gameObject);
        }
    }
}