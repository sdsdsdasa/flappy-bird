using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    // public connection between script, in this case LogicScript
    private bool Bird1Collision = false;
    private bool Bird2Collision = false;
    public BirdScript Bird1;
    public BirdScript2 Bird2;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Bird1 = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        if (ScenesManager.mode == "duo")
        {
            Bird2 = GameObject.FindGameObjectWithTag("Bird2").GetComponent<BirdScript2>();
        }
        // find the connection
    }

    public IEnumerator WaitBird1()
    {
        Bird1Collision = true;
        yield return new WaitForSeconds(0.5f);
        Bird1Collision = false;
    }

    public IEnumerator WaitBird2()
    {
        Bird2Collision = true;
        yield return new WaitForSeconds(0.5f);
        Bird2Collision = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
        // providing collision effect
    {
        if (collision.gameObject.layer == 3 && Bird1Collision == false)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Bird1.GetComponent<Collider2D>(), true);
            if (Bird1.birdIsAlive == true)
            {
                logic.addScore(1);
                
                //WaitBird1();
            }
        }
        if (collision.gameObject.layer == 7 && Bird2Collision == false)
        {
            if (Bird2.bird2IsAlive == true)
            {
                logic.addScore2(1);
                //WaitBird2();
            }    
        }
        
        
    }
}


