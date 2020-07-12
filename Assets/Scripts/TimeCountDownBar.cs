using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCountDownBar : MonoBehaviour
{
    public GameObject gameManager;
    float time;
    float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        time = gameManager.GetComponent<GameWaves>().nextWaveTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = gameManager.GetComponent<GameWaves>().waveTimeCountDown;
        transform.localScale = new Vector3((float)timeLeft/time,1,1);
    }
}
