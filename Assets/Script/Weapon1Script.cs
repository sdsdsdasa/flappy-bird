using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1Script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public BirdScript Bird1Status;
    public Transform BirdPosition;
    public GameObject Bird1;
    public bool Avalible = true;
    

    // Start is called before the first frame update
    void Start()
    {
        Bird1Status = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Bird1.GetComponent<Collider2D>(), true);
        Hide();
    }

    public void Show()
    {
        if (Avalible == true)
        {
            transform.position = BirdPosition.position;
            myRigidbody.velocity = Vector2.right;
        }
    }

    public void Hide()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position = new Vector2(0, 80);
        myRigidbody.velocity = new Vector2(0, 0);
    }


    public IEnumerator WaitTen()
    {
        Avalible = false;
        yield return new WaitForSeconds(10f);
        Avalible = true;
    }

    public IEnumerator WaitFive()
    {
        Avalible = false;
        yield return new WaitForSeconds(5f);
        Avalible = true;
    }


        private void Update()
    {
        myRigidbody.velocity = myRigidbody.velocity + Vector2.right;
        if (Input.GetKeyDown(KeyCode.Q) == true && Bird1Status.birdIsAlive == true)
        {
            Show();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "Pipe")
        {
            Destroy(collision.gameObject);
            StartCoroutine(WaitFive());
        }
        if (collision.transform.gameObject.layer == 7)
        {
            StartCoroutine(WaitTen());
        }
    }
}