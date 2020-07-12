using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void GameManagerEventHandler();
    public event GameManagerEventHandler RestartLevelEvent;
    public event GameManagerEventHandler GameOverEvent;
    public event GameManagerEventHandler GameStartEvent;

    public bool isGameOver;
    public int enemyDiedNum = 0;
    public int playerPoint = 0;

    public Text playerPointText;

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
        playerPointText = GameObject.Find("PlayerPoint").GetComponent<Text>();
        playerPointText.text = playerPoint.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPointText.text = playerPoint.ToString();
    }

}
