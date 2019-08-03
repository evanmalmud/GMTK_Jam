using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnPointsController : MonoBehaviour
{
    public GameObject BasicEnemyPrefab;
    public GameObject MediumEnemyPrefab;
    public GameObject HardEnemyPrefab;

    private List<Transform> points = new List<Transform>();

    [SerializeField]
    private int wave;

    public float mediumEnemyTimer;

    private System.Random random;

    private int basicEnemyIndex;
    private bool secondSpawnDone, thirdSpawnDone, fourthSpawnDone, fifthSpawnDone;
    private bool secondRandomSpawnLaunched;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++) {
            points.Add(transform.GetChild(i));
        }

        StartCoroutine(nameof(SpawnBasicEnemy));

        random = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GetInstance().GetBasicEnemeiesDefeated() == 5) {
            SpawnMediumEnemies();
        }
    }

    IEnumerator SpawnBasicEnemy() {
        SpawnEnemy("basic", false, basicEnemyIndex);

        yield return new WaitForSeconds(3);
        
        basicEnemyIndex = (basicEnemyIndex + 1)%points.Count;
        SpawnBasicEnemy();
    }

    // ReSharper disable once FunctionRecursiveOnAllPaths
    IEnumerator SecondRandomSpawn() {
        SpawnEnemy("medium", true);

        yield return new WaitForSeconds(random.Next(7, 20));

        SecondRandomSpawn();
    }

    IEnumerator SpawnMediumEnemies() {
        mediumEnemyTimer += Time.deltaTime;

        if(mediumEnemyTimer > 600) {
            // spawn 6
            if(!fifthSpawnDone) {
                // spawn 6 : 2 in all entries + random spawn every from 7 to 20s
                for(int i = 0; i < points.Count; i++) {
                    SpawnEnemy("medium", false, i);
                    SpawnEnemy("medium", false, i);
                }

                fifthSpawnDone = true;

                SecondRandomSpawn();
                SpawnMediumEnemies();
            }
        } else if(mediumEnemyTimer > 480) {
            // spawn 5
            if(!fifthSpawnDone) {
                // spawn 5 : 2 in all entries
                for(int i = 0; i < points.Count; i++) {
                    SpawnEnemy("medium", false, i);
                    SpawnEnemy("medium", false, i);
                }

                fifthSpawnDone = true;

                SpawnMediumEnemies();
            }
        } else if(mediumEnemyTimer > 300) {
            // spawn 4
            if(!fourthSpawnDone) {
                // spawn 4 : 1 in all entries
                for(int i = 0; i < points.Count; i++) {
                    SpawnEnemy("medium", false, i);
                }

                fourthSpawnDone = true;

                SpawnMediumEnemies();
            }
        } else if(mediumEnemyTimer > 180) {
            // spawn 3
            if(!thirdSpawnDone) {
                // spawn 3 : 1 in 3 random entries
                int r1 = random.Next(points.Count);
                int r2 = random.Next(points.Count);
                int r3 = random.Next(points.Count);
                while(r1 == r2)
                    r2 = random.Next(points.Count);
                while(r1 == r3 || r2 == r3)
                    r3 = random.Next(points.Count);
                
                SpawnEnemy("medium", false, r1);
                SpawnEnemy("medium", false, r2);
                SpawnEnemy("medium", false, r3);

                thirdSpawnDone = true;

                SpawnMediumEnemies();
            }
        } else if(mediumEnemyTimer > 90) {
            // spawn 2
            if(!secondSpawnDone) {
                // spawn 2 : 1 in 2 random entries
                int r1 = random.Next(points.Count);
                int r2 = random.Next(points.Count);
                while(r1 == r2)
                    r2 = random.Next(points.Count);
                
                SpawnEnemy("medium", false, r1);
                SpawnEnemy("medium", false, r2);

                secondSpawnDone = true;

                SpawnMediumEnemies();
            }
        } else {
            // spawn 1
            yield return new WaitForSeconds(7);
            SpawnEnemy("medium", true);
            SpawnMediumEnemies();
        }
    }

    void SpawnEnemy(string type, bool isRandom, int index = 0) {
        Transform entry;

        if(isRandom) {
            entry = points[random.Next(0, points.Count)];
        } else {
            entry = points[index];
        }

        GameObject prefab;
        switch(type) {
            default:
                prefab = BasicEnemyPrefab;
                break;
        }

        Instantiate(prefab, entry.position, Quaternion.identity);
    }
}
