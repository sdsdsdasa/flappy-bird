using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    // public connection between script, in this case LogicScript

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // find the connection
    }

    public void OnTriggerEnter2D(Collider2D collsion)
        // providing collision effect
    {
        if (collsion.gameObject.layer == 3)
        {
            logic.addScore(1);
        }
        if (collsion.gameObject.layer == 7)
        {
            logic.addScore2(1);
        }
        
        
    }
}
