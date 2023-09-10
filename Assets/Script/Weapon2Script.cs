using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2Script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public BirdScript2 Bird2Status;
    public Transform BirdPosition;
    public GameObject Bird2;
    public GameObject Weapon1;
    public bool Avalible = true;
    public bool OnScreen = false;
    public float rotationSpeed = 800.0f;

    void Start()
    {
        Bird2Status = GameObject.FindGameObjectWithTag("Bird2").GetComponent<BirdScript2>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Bird2.GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Weapon1.GetComponent<Collider2D>(), true);
        //Hide();
    }

    //public void Show()
    //{
    //    if (Avalible == true)
    //    {
    //        transform.position = BirdPosition.position;
    //        OnScreen = true;
    //    }
    //}

    //public void Hide()
    //{
    //    transform.rotation = new Quaternion(0, 0, 0, 0);
    //    transform.position = new Vector2(0, 80);
    //    myRigidbody.velocity = new Vector2(0, 0);
    //    OnScreen = false;
    //}


    //public IEnumerator WaitTen()
    //{
    //    Avalible = false;
    //    yield return new WaitForSeconds(10f);
    //    Avalible = true;
    //}


    //public IEnumerator ShowAndHide()
    //{
    //    Show();
    //    yield return new WaitForSeconds(3f);
    //    Hide();
    //    Debug.Log("F");
    //    Avalible = false;
    //    yield return new WaitForSeconds(5f);
    //    Debug.Log("T");
    //    Avalible = true;
    //}


    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        //if (Input.GetKeyDown(KeyCode.M) == true && Bird2Status.bird2IsAlive == true)
        //{
        //    transform.position = BirdPosition.position;
        //    //StartCoroutine(ShowAndHide());
        //}
        //if (OnScreen == true)
        //{
        //    transform.position = BirdPosition.position;
        //}

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.gameObject.tag == "Pipe")
        {
            Destroy(collision.gameObject);

        }
    }
}