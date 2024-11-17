using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawn_rate = 2;
    private float spawn_rnd;
    private float spawn_rnd_offset = .5f;
    private float timer = 0;
    public float heightOffset = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
        spawn_rnd = Random.Range(-spawn_rnd_offset, spawn_rnd_offset);
    }

    // Update is called once per frame
    void Update()
    {   
        if(timer < (spawn_rate + spawn_rnd))
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
            spawn_rnd = Random.Range(-spawn_rnd_offset, spawn_rnd_offset);
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(
            pipe,
            new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0),
            transform.rotation
        );
    }
}
