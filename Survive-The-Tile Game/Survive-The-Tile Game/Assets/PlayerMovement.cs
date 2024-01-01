using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    //A - Left/Upper
    //B - Rigth/Lower
    public int result;
    public int count = 0;
    public string locator;
    public Rigidbody2D player;
    public int timer = 3;
    public int jump = 20;
    private float successRate;

    public GameObject lb;
    public GameObject rb;
    public GameObject pauseMenue;
    public GameObject winningScreen;

    public Text text;
    public int score = 0;

    [Header("Light")]
    [SerializeField] private Sprite greenLight;
    [SerializeField] private Sprite redLight;
    public GameObject ligth;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(score < 6)
            {
                player.AddForce(new Vector2(player.transform.position.x, jump));
                locator = "L" + count.ToString();
                Vector3 position = GameObject.FindGameObjectWithTag(locator).transform.position;
                Debug.Log(position);
                player.transform.position = new Vector3(position.x, position.y + 1, position.z);
                count++;
            }
            else if(score==6)
            {
                Debug.Log("Wind");
                wonCondition();
                Invoke("showWinningScreen", 1);
            }
            

        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if(score <6)
            {
                locator = "R" + count.ToString();
                Vector3 position = GameObject.FindGameObjectWithTag(locator).transform.position;
                Debug.Log(position);
                player.transform.position = new Vector3(position.x, position.y + 1, position.z);
                count++;
            }
            else if(score == 6)
            {
                Debug.Log("Wind");
                wonCondition();
                Invoke("showWinningScreen", 1);
            }
           
        }

    }

    public void simulateA()
    {
        if (score < 6)
        {
            player.AddForce(new Vector2(player.transform.position.x, jump));
            locator = "L" + count.ToString();
            Vector3 position = GameObject.FindGameObjectWithTag(locator).transform.position;
            Debug.Log(position);
            player.transform.position = new Vector3(position.x, position.y + 1, position.z);
            count++;
        }
        else if (score == 6)
        {
            Debug.Log("Wind");
            wonCondition();
            Invoke("showWinningScreen", 1);
        }
    }

    public void simulateB()
    {
        if (score < 6)
        {
            locator = "R" + count.ToString();
            Vector3 position = GameObject.FindGameObjectWithTag(locator).transform.position;
            Debug.Log(position);
            player.transform.position = new Vector3(position.x, position.y + 1, position.z);
            count++;
        }
        else if (score == 6)
        {
            Debug.Log("Wind");
            wonCondition();
            Invoke("showWinningScreen", 1);
        }
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(locator))
        {
            Debug.Log("A Pressed");
           
            successRate = Random.Range(0.0f , 0.5f);
            Debug.Log("Decider for A is" + result);
            Debug.Log("Count is" + count.ToString());
            if(successRate > 0.25)
            {
                ligth.GetComponent<SpriteRenderer>().sprite = redLight;
                
                Invoke("afterMath", 1);
                Invoke("showPauseMenu", 2);
                
            }
            else if (successRate <= 0.25)
            {
                score = score + 1;
                text.text = "Score : "+score.ToString();
                ligth.GetComponent<SpriteRenderer>().sprite = greenLight;
                
            }
        }
    }

    public void afterMath()
    {
        int referenceCount = count - 1;
        string LeftBoxReference = "L" + referenceCount.ToString();
        string RightBoxReference = "R" + referenceCount.ToString();
        Debug.Log(LeftBoxReference + RightBoxReference);
        GameObject.FindWithTag(LeftBoxReference).GetComponent<Rigidbody2D>().gravityScale = 4;
        player.gravityScale = 3;
        GameObject.FindWithTag(RightBoxReference).GetComponent<Rigidbody2D>().gravityScale = 4;
    }

    public void wonCondition() { 
        Vector3 position = GameObject.FindWithTag("End").transform.position;
        player.transform.position  = new Vector3(position.x , position.y + 1 , position.z);
    }

    public void showWinningScreen()
    {
        winningScreen.SetActive(true);
    }
    public void showPauseMenu()
    {
       pauseMenue.SetActive(true);
    }
        
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void resume()
    {
        pauseMenue.SetActive(false);
    }


    public void mintWinningNft()
    {
        Debug.Log("Not Supported Yet");
    }

}
