using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject turretToBuild;
    public static GameManager instance;

    public GameObject pausePanel;

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
        instance = this;
        playerPointText = GameObject.Find("PlayerPoint").GetComponent<Text>();
        playerPointText.text = playerPoint.ToString();
        turretToBuild = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPointText.text = playerPoint.ToString();
    }

    public void selectTurretToBuild() 
    {
        turretToBuild = (GameObject)Resources.Load("Turret");
    }

    public void PauseGame() 
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);

    }

    public void LoadMainMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveGameData() 
    {
        SaveSystem.SaveGameData();
        PlayerPrefs.SetInt("ScenceSaved",SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadGameData() 
    {
        GameData data = SaveSystem.LoadGameData();

        playerPoint = data.playerPoint;
        enemyDiedNum = data.enemyKilledNum;
    }
}
