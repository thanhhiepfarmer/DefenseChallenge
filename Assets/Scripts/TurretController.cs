using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretController : MonoBehaviour
{
    public GameObject target;
    public float range = 5f;
    public int damage  = 1;
    public Transform gun;
    public LineRenderer laze;
    public float fireRate = 0.5f;
    public Canvas canvas;
    private int level =1;
    public Text levelTxt;
    private int pointForLevelup = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    void UpdateTarget() 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortest = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position,enemy.transform.GetChild(0).transform.position);
            if (distance < shortest)
            {
                shortest = distance;
                nearestEnemy = enemy;
            }
        }

        if ((nearestEnemy != null) && (shortest <= range))
        {
            target = nearestEnemy;
        }
        else
            target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            laze.SetPosition(0,transform.position);
            laze.SetPosition(1,transform.position);
            return;
        }
        //look at enemy in range immediately
        gun.LookAt(target.transform.GetChild(0).position);
        //Shoot
        Shoot();
    }

    private void Shoot()
    {
        laze.SetPosition(0,gun.transform.position);
        laze.SetPosition(1,target.transform.GetChild(0).position);
        if (fireRate <= 0)
        { 
            target.GetComponent<HitPoint>().hitPoint -= damage;
            fireRate = 0.5f;
        }
        fireRate -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }

    private void OnMouseEnter()
    {
        canvas.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        canvas.gameObject.SetActive(false);
    }

    public void LevelUpTurret() 
    {
        if (GameManager.instance.playerPoint < pointForLevelup)
            return;
        level++;
        GameManager.instance.playerPoint -= pointForLevelup;
        damage *= 2;
        pointForLevelup *= 2;

        levelTxt.text = "Level " + level;
    }
}
