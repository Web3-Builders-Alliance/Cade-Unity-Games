using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidBody2D;
    public float flapStrenght;
    public LogicScript logic;
    public bool birdIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -15)
        {
            logic.gameOver();
        }
        flapBird();
    }

    public void flapBird()
    {
        if (Input.GetMouseButtonDown(0) && birdIsAlive)
        {
            myRigidBody2D.velocity = Vector2.up * flapStrenght;
         
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    
}
