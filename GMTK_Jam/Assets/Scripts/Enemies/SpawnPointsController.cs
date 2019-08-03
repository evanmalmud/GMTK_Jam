using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsController : MonoBehaviour
{
    public GameObject BasicEnemyPrefab;
    // ReSharper disable once NotAccessedField.Global
    public GameObject MediumEnemyPrefab;
    // ReSharper disable once NotAccessedField.Global
    public GameObject HardEnemyPrefab;

    private readonly List<Transform> points = new List<Transform>();

    public float mediumEnemyTimer;

    private System.Random random;

    private int basicEnemyIndex;
    private bool secondSpawnDone, thirdSpawnDone, fourthSpawnDone, fifthSpawnDone;
    private bool secondRandomSpawnLaunched;

    private float thirdStepTimer;
    private bool tsSecondWave, tsThirdWave, tsFourthWave, tsFifthWave;

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
            StartCoroutine(SpawnMediumEnemies());
        }
        if(GameManager.GetInstance().GetMediumEnemeiesDefeated() == 5) {
            StartCoroutine(ThirdStepSpawns());
        }
    }

    IEnumerator SpawnBasicEnemy() {
        Debug.Log("basic spawn");
        SpawnEnemy("basic", false, basicEnemyIndex);

        yield return new WaitForSeconds(3);
        
        basicEnemyIndex = (basicEnemyIndex + 1)%points.Count;
        yield return SpawnBasicEnemy();
    }

    // ReSharper disable once FunctionRecursiveOnAllPaths
    // ReSharper disable once UnusedMethodReturnValue.Local
    IEnumerator SecondRandomSpawn() {
        SpawnEnemy("medium", true);

        yield return new WaitForSeconds(random.Next(7, 21));

        yield return SecondRandomSpawn();
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

                StartCoroutine(SecondRandomSpawn());
            }
            
            yield return SpawnMediumEnemies();
        } else if(mediumEnemyTimer > 480) {
            // spawn 5
            if(!fifthSpawnDone) {
                // spawn 5 : 2 in all entries
                for(int i = 0; i < points.Count; i++) {
                    SpawnEnemy("medium", false, i);
                    SpawnEnemy("medium", false, i);
                }

                fifthSpawnDone = true;
            }

            yield return SpawnMediumEnemies();
        } else if(mediumEnemyTimer > 300) {
            // spawn 4
            if(!fourthSpawnDone) {
                // spawn 4 : 1 in all entries
                for(int i = 0; i < points.Count; i++) {
                    SpawnEnemy("medium", false, i);
                }

                fourthSpawnDone = true;
            }

            yield return SpawnMediumEnemies();
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
            }

            yield return SpawnMediumEnemies();
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
            }

            yield return SpawnMediumEnemies();
        } else {
            // spawn 1
            yield return new WaitForSeconds(7);
            SpawnEnemy("medium", true);
            yield return SpawnMediumEnemies();
        }
    }

    IEnumerator ThirdStepRandomSpawns()
    {
        yield return new WaitForSeconds(random.Next(13, 26)); // 13-25s
        SpawnEnemy("hard", true);

        ThirdStepRandomSpawns();
    }

    IEnumerator ThirdStepSpawns()
    {
        thirdStepTimer += Time.deltaTime;

        if (thirdStepTimer > 900)
        {
            // spawn 5
        } else if (thirdStepTimer > 600)
        {
            // spawn 4
            if (!tsFourthWave)
            {
                // spawn 4 : 2 in all entries + random spawn for 13 to 25 seconds
                for(int i = 0; i < points.Count; i++) {
                    SpawnEnemy("hard", false, i);
                    SpawnEnemy("hard", false, i);
                }

                tsFourthWave = true;

                ThirdStepRandomSpawns();
            }
        } else if (thirdStepTimer > 300)
        {
            // spawn 3
            if (!tsThirdWave)
            {
                // spawn 3 : 1 in all entries
                for(int i = 0; i < points.Count; i++) {
                    SpawnEnemy("hard", false, i);
                    SpawnEnemy("hard", false, i);
                }

                tsThirdWave = true;
            }

            ThirdStepSpawns();
        } else if (thirdStepTimer > 120)
        {
            // spawn 2
            if (!tsSecondWave)
            {
                // spawn 2 : 1 in all entries
                for(int i = 0; i < points.Count; i++) {
                    SpawnEnemy("hard", false, i);
                }

                tsSecondWave = true;
            }

            ThirdStepSpawns();
        }
        else
        {
            // spawn 1 : on random entry every 13s
            SpawnEnemy("hard", true);
            
            yield return new WaitForSeconds(13);

            ThirdStepSpawns();
        }
    }

    void SpawnEnemy(string type, bool isRandom, int index = 0)
    {
        Debug.Log("spawning");
        
        var entry = isRandom ? points[random.Next(0, points.Count)] : points[index];

        GameObject prefab;
        switch(type) {
            default:
                prefab = BasicEnemyPrefab;
                break;
        }

        Instantiate(prefab, entry.position, Quaternion.identity);
    }
}
