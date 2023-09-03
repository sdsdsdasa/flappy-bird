using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    // public connection between script, in this case LogicScript
    private bool Bird1Collision = false;
    private bool Bird2Collision = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
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

    public void OnTriggerEnter2D(Collider2D collsion)
        // providing collision effect
    {
        if (collsion.gameObject.layer == 3 && Bird1Collision == false)
        {
            logic.addScore(1);
            WaitBird1();

        }
        if (collsion.gameObject.layer == 7 && Bird2Collision == false)
        {
            logic.addScore2(1);
            WaitBird2();
        }
        
        
    }
}


