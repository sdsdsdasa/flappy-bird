using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript2 : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    // make physics work with the bird
    public float flapStrength = 20;
    // create an float variable
    public LogicScript logic;
    public bool bird2IsAlive = true;
    public float deadZone = -12;
    private float initialSpeed = 10;
    private bool playDeathSound = true;
    private float flapStrengthHorizontal = 10;

    [SerializeField] private AudioSource DeathSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myRigidbody.velocity = Vector2.up * initialSpeed;
        if (ScenesManager.gravity > 0)
        {
            myRigidbody.gravityScale = ScenesManager.gravity;
        }
        if (ScenesManager.birdStrength > 0)
        {
            flapStrength = ScenesManager.birdStrength;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //myRigidbody.gravityScale = ScenesManager.gravity;

        if (Input.GetKeyDown(KeyCode.UpArrow) == true && bird2IsAlive == true)
        {
            flyUp();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) == true && bird2IsAlive == true)
        {
            flyLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) == true && bird2IsAlive == true)
        {
            flyRight();
        }

        if (transform.position.y < deadZone)
        {
            //logic.gameOver();
            bird2IsAlive = false;
        }
        else if (transform.position.y > -1 * deadZone)
        {
            //logic.gameOver();
            bird2IsAlive = false;
        }

        if (bird2IsAlive == false & playDeathSound == true)
        {
            DeathSoundEffect.Play();
            playDeathSound = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "Pipe")
        {
            bird2IsAlive = false;
        }
    }

    public void flyUp()
    {
        if (bird2IsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    public void flyLeft()
    {
        if (bird2IsAlive == true)
        {
            myRigidbody.velocity = myRigidbody.velocity + Vector2.left * flapStrengthHorizontal;
        }
    }

    public void flyRight()
    {
        if (bird2IsAlive == true)
        {
            myRigidbody.velocity = myRigidbody.velocity + Vector2.right * flapStrengthHorizontal;
        }
    }
}