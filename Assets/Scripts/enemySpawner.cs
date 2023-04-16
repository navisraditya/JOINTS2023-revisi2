using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    // public List<GameObject> spawnedEnemy = new List<GameObject>();
    public List<GameObject> enemyToSpawn = new List<GameObject>();
    public List<Transform> spawnPosition = new List<Transform>();

    int currentWave;
    [SerializeField] int waveCount;
    [SerializeField] int spawnCost;
    [SerializeField] float spawnTimePerWave;
    float spawnTimePerUnit;
    int curSpawnCost;

    Coroutine spawnRoutine;

    void Start()
    {
        curSpawnCost = spawnCost;
        generateWave();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentWave == waveCount) return;

        if(transform.childCount == 0 && spawnRoutine == null){
            spawnRoutine = StartCoroutine(spawnEnemy());
        }
        // else{
        //     if(spawnedEnemy.Count > 0 && spawnedEnemy[0] == null){
        //         spawnedEnemy.RemoveAt(0);
        //     }
        // }
    }
    
    public bool isFinishRunning(){
        return currentWave == waveCount && transform.childCount == 0;
    }
    private IEnumerator spawnEnemy(){
        yield return new WaitForSeconds(3f);
        int numEnemy = enemyToSpawn.Count;
        for(int i = 0; i < numEnemy; i++){
            int spwanPosIdx = Random.Range(0, spawnPosition.Count);
            GameObject enemy = Instantiate(enemyToSpawn[i], spawnPosition[spwanPosIdx].position, Quaternion.identity, transform);
            enemy.SetActive(true);
            yield return new WaitForSeconds(spawnTimePerUnit);
        }
        enemyToSpawn.Clear();
        spawnRoutine = null;
        currentWave++;
        generateEnemies();
    }
    void generateWave(){
        generateEnemies();
    }

    void generateEnemies(){
        int numEnemy = enemies.Count;
        while(curSpawnCost > 0){
            int enemyIdx = Random.Range(0, numEnemy);
            curSpawnCost -= enemies[enemyIdx].cost;
            enemyToSpawn.Add(enemies[enemyIdx].enemyPrefab);
        }
        curSpawnCost = spawnCost;
        spawnTimePerUnit = spawnTimePerWave / enemyToSpawn.Count;
    }
}


[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
