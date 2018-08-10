using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    // Use this for initialization

    public GameObject[] spawnPoints;

    public GameObject bossSpawnPoint;

    public int enemiesPerWave = 5;

    public int Waves = 5;

    public GameObject[] enemies;
    public GameObject boss;

    private int currWave;

    bool hasEnemy;

	void Start () {
        currWave = 1;
        hasEnemy = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindWithTag("Enemy") == null && hasEnemy)
        {
            currWave++;
            spawnWave();
            if (currWave > Waves)
            {
                spawnBoss();
                hasEnemy = false;
            }
        }

        if (GameObject.FindWithTag("Enemy") == null && !hasEnemy)
        {
            GameObject.Find("UIManager").GetComponent<UIManager>().playerWin();
        }

        
	}

    void spawnWave()
    {
        for (int i = 0; i < enemiesPerWave; ++i)
        {
            int currEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[currEnemy], spawnPoints[i].transform.position, Quaternion.identity);
        }
    }

    void spawnBoss()
    {
        Instantiate(boss, bossSpawnPoint.transform.position, Quaternion.identity);
    }

    public bool hasNextEnemy()
    {
        return hasEnemy;
    }
}
