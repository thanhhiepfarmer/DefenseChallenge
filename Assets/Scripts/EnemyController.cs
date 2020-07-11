using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject spider;
    private GameObject environment;
    private int nextPointNo;
    private Transform[] waypoint;

    void Start()
    {
        environment = GameObject.Find("Environment");
        waypoint = environment.GetComponent<EnvironmentController>().waypoint;
        gameObject.transform.position = new Vector3(waypoint[0].position.x,0, waypoint[0].position.z);
        nextPointNo = 1;
        spider.transform.LookAt(waypoint[nextPointNo]);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(spider.transform.position, waypoint[nextPointNo].position) < 0.2f)
        {
            nextPointNo++;
            if (nextPointNo >= waypoint.Length)
            {
                Destroy(gameObject);
            }else
            spider.transform.LookAt(waypoint[nextPointNo]);
        }
    }
}
