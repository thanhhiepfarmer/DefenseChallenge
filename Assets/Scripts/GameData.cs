using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int playerPoint;
    public int enemyKilledNum;

    public GameData()
    {
        playerPoint = GameManager.instance.playerPoint;
        enemyKilledNum = GameManager.instance.enemyDiedNum;
    }
}
