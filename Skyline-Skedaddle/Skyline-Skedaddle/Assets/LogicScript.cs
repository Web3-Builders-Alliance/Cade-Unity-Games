using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;


    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    { 
      playerScore = playerScore + scoreToAdd;
      scoreText.text = playerScore.ToString();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }

    public void gameOver() 
    {
      gameOverScreen.SetActive(true);   

    }


}
