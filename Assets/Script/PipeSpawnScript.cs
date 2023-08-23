using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject Pipe1;
    public GameObject Pipe2;
    public GameObject Pipe3;
    private GameObject ThePipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
        if (ScenesManager.level == "Easy")
        {
            Debug.Log("Mode easy");
            ThePipe = Pipe1;
        }
        else if (ScenesManager.level == "Hard")
        {
            ThePipe = Pipe2;
        }
        else if (ScenesManager.level == "Extreme" || ScenesManager.level == "ExtremeExtreme")
        {
            ThePipe = Pipe3;
        }

        if (ScenesManager.pipeSpawnRate > 0)
        {
            spawnRate = ScenesManager.pipeSpawnRate;
        }
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowerstPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        
        Instantiate(ThePipe, new Vector3(transform.position.x, Random.Range(lowerstPoint, highestPoint), 0), transform.rotation);
    }
}
