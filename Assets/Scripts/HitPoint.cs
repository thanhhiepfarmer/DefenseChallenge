using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHP;
    public int hitPoint;
    public GameManager manager;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        maxHP = 1 + (int) (manager.enemyDiedNum / 10);
        hitPoint = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        checkHP();
    }

    private void checkHP()
    {
        if (hitPoint <= 0)
        { 
            Destroy(gameObject);
            manager.enemyDiedNum++;
            manager.playerPoint += 1;
        }
    }
}
