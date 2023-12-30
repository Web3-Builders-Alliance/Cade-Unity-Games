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
    //decider - 0 OK
    //decider - 1 Fall

    public int result;
    public int count = 0;
    public string locator;
    public Rigidbody2D player;
    public int timer = 3;
    public int jump = 20;

    public GameObject lb;
    public GameObject rb;
    public GameObject pauseMenue;
    public GameObject winningScreen;

    public Text text;
    public int score = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && score<6)
        {
            player.AddForce(new Vector2 (player.transform.position.x , jump));
            locator = "L" + count.ToString();
            Vector3 position = GameObject.FindGameObjectWithTag(locator).transform.position;
            Debug.Log(position);
            player.transform.position = new Vector3(position.x , position.y+ 1 , position.z);
            count++;

        }

        if (Input.GetKeyDown(KeyCode.B) && score < 6)
        {
            locator = "R" + count.ToString();
            Vector3 position = GameObject.FindGameObjectWithTag(locator).transform.position;
            Debug.Log(position);
            player.transform.position = new Vector3(position.x, position.y + 1, position.z);
            count++;
        }

        if(Input.GetKeyDown(KeyCode.A) && score == 6)
        {
            Debug.Log("Wind");
            wonCondition();
            Invoke("showWinningScreen", 1);
        }

        if (Input.GetKeyDown(KeyCode.B) && score == 6)
        {
            Debug.Log("Wind");
            wonCondition();
            Invoke("showWinningScreen", 1);
        }

    }

    public int generateRandom()
    {
        int decider = Random.Range(0, 2);
        return decider;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(locator))
        {
            Debug.Log("A Pressed");
            result = generateRandom();
            Debug.Log("Decider for A is" + result);
            Debug.Log("Count is" + count.ToString());
            //player.transform.position = new Vector3(0,1.0F ,0);
            if(result==1)
            {
                GameObject.Find("Light").GetComponent<Renderer>().material.color = Color.red;
                GameObject.Find("Light2").GetComponent<Renderer>().material.color = Color.red;
                GameObject.Find("Light3").GetComponent<Renderer>().material.color = Color.red;
                
                Invoke("afterMath", 1);
                Invoke("showPauseMenu", 2);
                //showPauseMenu();
                
            }
            else if (result == 0)
            {
                score = score + 1;
                text.text = "Score : "+score.ToString();
                GameObject.Find("Light").GetComponent<Renderer>().material.color = Color.green;
                GameObject.Find("Light2").GetComponent<Renderer>().material.color = Color.green;
                GameObject.Find("Light3").GetComponent<Renderer>().material.color = Color.green;
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

    public void quit()
    {
        Application.Quit();
    }

    public void mintWinningNft()
    {
        Debug.Log("Not Supported Yet");
    }

}
