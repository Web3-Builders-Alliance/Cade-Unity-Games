using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenue;
    void Start()
    {
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pauseMenue.activeSelf)
            {
                Time.timeScale = 0f;
                pauseMenue.SetActive(true);
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1f;
                pauseMenue.SetActive(false);
                Cursor.visible=false;
            }
        }        
    }

    public void quit()
    {
        Application.Quit();
    }

    public void resume()
    {
        Time.timeScale = 1f;
        pauseMenue.SetActive(false);
        Cursor.visible = false; 
    }

}
