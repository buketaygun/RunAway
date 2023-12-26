using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
    }

    
    void Update()
    {
        if (GameControl.gameOver == true)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        
    }
}
