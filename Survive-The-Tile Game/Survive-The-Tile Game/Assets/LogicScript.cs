using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update

    //A - Left/Upper
    //B - Rigth/Lower
    //decider - 0 OK
    //decider - 1 Fall

    private int decider;
    private int count = 1;
    private string locator;
    public GameObject player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            locator = "L" + count.ToString();
            Vector3 position = GameObject.FindGameObjectWithTag(locator).transform.position;
            Debug.Log(position);
            player.transform.position = position;

            void OnCollisionEnter2D(Collision2D collision)
            {

                if (collision.gameObject.CompareTag(locator))
                {
                    count = count + 1;
                    Debug.Log("A Pressed");
                    int deciderforA = generateRandom();
                    Debug.Log("Decider for A is" + deciderforA);
                    Debug.Log("Count is" + count.ToString());


                }
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            count = count + 1;
            Debug.Log("B Pressed");
            int deciderforB = generateRandom();
            Debug.Log("Decider for B is" + deciderforB);
            Debug.Log("Count is" + count.ToString());
            string locator = "R" + count.ToString();
            Vector3 position = GameObject.FindGameObjectWithTag(locator).transform.position;
            Debug.Log(position);

            player.transform.position = position;


        }
    }

    int generateRandom()
    {
        decider = Random.Range(0, 2);
        return decider;
    }

   
}