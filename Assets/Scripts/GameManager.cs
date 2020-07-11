using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void GameManagerEventHandler();
    public event GameManagerEventHandler RestartLevelEvent;
    public event GameManagerEventHandler GameOverEvent;
    public event GameManagerEventHandler GameStartEvent;

    public bool isGameOver;
    public int enemyDiedNum = 0;

    public void CallEventRestartLevel() 
    {
        if (RestartLevelEvent != null)
            RestartLevelEvent();
    }

    public void CallEventGameStart()
    {
        if (GameStartEvent != null)
        {
            isGameOver = false;
            GameStartEvent();
        }
    }

    public void CallEventGameOver()
    {
        if (GameOverEvent != null)
        {
            isGameOver = true;
            GameOverEvent();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
