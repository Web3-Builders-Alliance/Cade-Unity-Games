using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("UI objects")]
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject outOfTimeText;
    [SerializeField] private GameObject bombText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text scoreText;



    [SerializeField] private List<Mole> moles;

    private float startingTime = 30f;

    //Global variables
    private float timeRemaining;
    private HashSet<Mole> currentMoles = new HashSet<Mole> ();
    private int score;
    private bool playing = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playing)
        {
            timeRemaining -= Time.deltaTime;
            if(timeRemaining <=0 )
            { 
                timeRemaining = 0;
                GameOver(0);
            }
            timeText.text = $"{(int)timeRemaining / 60} :{(int)timeRemaining % 60:D2}";
            if(currentMoles.Count <= (score/10))
            {
                int index = Random.Range(0, moles.Count);
                if (!currentMoles.Contains(moles[index]))
                {
                    currentMoles.Add(moles[index]);
                    moles[index].Activate(score / 10);
                }
            }
        }
    }

    // this is public so the play button can see it
    public void StartGame()
    {
        // Hide/show the UI elements we dont want to use it
        playButton.SetActive (false);
        outOfTimeText.SetActive (false);
        bombText.SetActive (false);
        gameUI.SetActive (true);
        // Hide all the visible moles
        for (int i = 0; i < moles.Count; i++)
        {
            moles[i].Hide();
            moles[i].SetIndex(i);
        }
        // Remove any old game state
        currentMoles.Clear ();  
        // Start with 30 seconds
        timeRemaining = startingTime;
        score = 0;
        playing = true;
    }

    public void GameOver(int type)
    {
        if(type == 0 )
        {
            outOfTimeText.SetActive(true);
        } else
        {
            bombText.SetActive(true);
        }
        foreach (Mole mole in moles)
        {
            mole.StopGame();
        }
        playing = false;
        playButton.SetActive (true);
    }

    public void AddScore(int moleIndex)
    {
        score += 1;
        scoreText.text = $"{score}";
        timeRemaining += 1;
        currentMoles.Remove(moles[moleIndex]);

    }

    public void Missed(int moleIndex , bool isMole)
    {
        if(isMole)
        {
            timeRemaining -= 2;
        }
        currentMoles.Remove(moles[moleIndex]);
    }
    
}
