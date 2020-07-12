using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWaves : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class Wave
    { 
        public GameObject enemyType;
        public int enemySize;
        public float rate;
    }

    public enum WaveState { SPAWNING, WAITING, COUNTING }

    public Transform spawnPoint;
    public float nextWaveTime = 5f;
    public Wave[] waves;
    private int currentWaveNo;
    private WaveState state = WaveState.SPAWNING;
    public float waveTimeCountDown;
    private int nextWave = 0;
    void Start()
    {
        waveTimeCountDown = nextWaveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveTimeCountDown <= 0)
        {
            if (nextWave >= waves.Length)
            {
                return;
            }
            if (state != WaveState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
            nextWave++;
            waveTimeCountDown = nextWaveTime;
        }
        else
        {
            waveTimeCountDown -= Time.deltaTime;
            state = WaveState.COUNTING;
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = WaveState.SPAWNING;
        for (int i = 0; i < _wave.enemySize;i++)
        {
            Instantiate(Resources.Load("Enemy"),GameObject.Find("EnemyCollect").transform);
            yield return new WaitForSeconds(_wave.rate);
        }

        state = WaveState.WAITING;
        yield break;
    }
}
