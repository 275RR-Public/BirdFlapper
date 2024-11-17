using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D my_rigid;
    public float flap_strength;
    public GameObject wing_up;
    public GameObject wing_down;
    private float animate_length = .25f;
    private float timer;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < animate_length)
        {
            timer += Time.deltaTime;
        }
        else
        {
            stopFlapping();
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            startFlapping();
            my_rigid.velocity = Vector2.up * flap_strength;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(transform.position.y >= 23 || transform.position.y <= -22)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void startFlapping()
    {
        wing_up.SetActive(false);
        wing_down.SetActive(true);
        timer = 0;
    }

    private void stopFlapping()
    {
        wing_up.SetActive(true);
        wing_down.SetActive(false);
        timer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
