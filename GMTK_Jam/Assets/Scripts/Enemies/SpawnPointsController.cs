using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsController : MonoBehaviour
{
    public GameObject BasicEnemyPrefab;
    public GameObject MediumEnemyPrefab;
    public GameObject HardEnemyPrefab;

    
    public Transform BasicSpawnPoints;
    public readonly List<Transform> BasicPoints = new List<Transform>();
    
    public Transform MediumSpawnPoints;
    public readonly List<Transform> MediumPoints = new List<Transform>();

    public Transform HardSpawnPoints;
    private readonly List<Transform> HardPoints = new List<Transform>();

    private bool startedMediumSpawn;
    private float mediumEnemyTimer;

    private System.Random random;

    private int basicEnemyIndex;
    private bool secondSpawnDone, thirdSpawnDone, fourthSpawnDone, fifthSpawnDone;
    private bool secondRandomSpawnLaunched;

    private bool startHardSpawn;
    private float thirdStepTimer;
    private bool tsSecondWave, tsThirdWave, tsFourthWave, tsFifthWave;

    private bool basicSpawnRunning = false;

    private List<GameObject> allEnemies = new List<GameObject>();


    public int basicEnemyPerSecond = 3;
    public int randomMediumSpawnMin = 7;
    public int randomMediumSpawnMax = 21;
    public int randomHardSpawnMin = 13;
    public int randomHardSpawnMax = 26;
    //public float randomMediumSpawnMin = 7.0f;
    //public float randomBasicSpawnMax = 21.0f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < BasicSpawnPoints.childCount; i++) {
            BasicPoints.Add(BasicSpawnPoints.GetChild(i));
        }
        for(int i = 0; i < MediumSpawnPoints.childCount; i++) {
            MediumPoints.Add(MediumSpawnPoints.GetChild(i));
        }
        for(int i = 0; i < HardSpawnPoints.childCount; i++) {
            HardPoints.Add(HardSpawnPoints.GetChild(i));
        }

        random = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.GetInstance().IsGameActive())
        {
            //Kill all coroutines
            StopCoroutine(nameof(SpawnBasicEnemy));
            StopCoroutine(nameof(SecondRandomSpawn));
            StopCoroutine(nameof(SpawnMediumEnemies));
            StopCoroutine(nameof(ThirdStepRandomSpawns));
            StopCoroutine(nameof(ThirdStepSpawns));
            basicSpawnRunning = false;

            //Kill all existing enemies
            foreach (GameObject go in allEnemies)
                Destroy(go);
            return;
        }

        //If couroutines arent running start them
        if(!basicSpawnRunning)
        {
            StartCoroutine(nameof(SpawnBasicEnemy));
        }



        if (!startedMediumSpawn && GameManager.GetInstance().GetBasicEnemeiesDefeated() >= 5)
        {
            startedMediumSpawn = true;
            StartCoroutine(SpawnMediumEnemies());
        }
        if(!startHardSpawn && GameManager.GetInstance().GetMediumEnemeiesDefeated() >= 5)
        {
            startHardSpawn = true;
            StartCoroutine(ThirdStepSpawns());
        }
    }

    IEnumerator SpawnBasicEnemy() {
        basicSpawnRunning = true;
        SpawnEnemy("basic", false, basicEnemyIndex);

        yield return new WaitForSeconds(basicEnemyPerSecond);
        
        basicEnemyIndex = (basicEnemyIndex + 1)%BasicPoints.Count;
        yield return SpawnBasicEnemy();
    }

    // ReSharper disable once FunctionRecursiveOnAllPaths
    // ReSharper disable once UnusedMethodReturnValue.Local
    IEnumerator SecondRandomSpawn() {
        SpawnEnemy("medium", true);

        yield return new WaitForSeconds(random.Next(randomMediumSpawnMin, randomMediumSpawnMax));

        yield return SecondRandomSpawn();
    }

    IEnumerator SpawnMediumEnemies() {
        Debug.Log("Medium spawn");
        mediumEnemyTimer += Time.deltaTime;

        if(mediumEnemyTimer > 600) {
            // spawn 6
            if(!fifthSpawnDone) {
                // spawn 6 : 2 in all entries + random spawn every from 7 to 20s
                for(int i = 0; i < MediumPoints.Count; i++) {
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
                for(int i = 0; i < MediumPoints.Count; i++) {
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
                for(int i = 0; i < MediumPoints.Count; i++) {
                    SpawnEnemy("medium", false, i);
                }

                fourthSpawnDone = true;
            }

            yield return SpawnMediumEnemies();
        } else if(mediumEnemyTimer > 180) {
            // spawn 3
            if(!thirdSpawnDone) {
                // spawn 3 : 1 in 3 random entries
                int r1 = random.Next(MediumPoints.Count);
                int r2 = random.Next(MediumPoints.Count);
                int r3 = random.Next(MediumPoints.Count);
                while(r1 == r2)
                    r2 = random.Next(MediumPoints.Count);
                while(r1 == r3 || r2 == r3)
                    r3 = random.Next(MediumPoints.Count);
                
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
                int r1 = random.Next(MediumPoints.Count);
                int r2 = random.Next(MediumPoints.Count);
                while(r1 == r2)
                    r2 = random.Next(MediumPoints.Count);
                
                SpawnEnemy("medium", false, r1);
                SpawnEnemy("medium", false, r2);

                secondSpawnDone = true;
            }

            yield return SpawnMediumEnemies();
        } else {
            // spawn 1
            yield return new WaitForSeconds(randomMediumSpawnMin);
            SpawnEnemy("medium", true);
            yield return SpawnMediumEnemies();
        }
    }

    IEnumerator ThirdStepRandomSpawns()
    {
        yield return new WaitForSeconds(random.Next(randomHardSpawnMin, randomHardSpawnMax)); // 13-25s
        SpawnEnemy("hard", true);

        yield return ThirdStepRandomSpawns();
    }

    IEnumerator ThirdStepSpawns()
    {
        Debug.Log("Hard spawn");
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
                for(int i = 0; i < HardPoints.Count; i++) {
                    SpawnEnemy("hard", false, i);
                    SpawnEnemy("hard", false, i);
                }

                tsFourthWave = true;

                yield return ThirdStepRandomSpawns();
            }
        } else if (thirdStepTimer > 300)
        {
            // spawn 3
            if (!tsThirdWave)
            {
                // spawn 3 : 1 in all entries
                for(int i = 0; i < HardPoints.Count; i++) {
                    SpawnEnemy("hard", false, i);
                    SpawnEnemy("hard", false, i);
                }

                tsThirdWave = true;
            }

            yield return ThirdStepSpawns();
        } else if (thirdStepTimer > 120)
        {
            // spawn 2
            if (!tsSecondWave)
            {
                // spawn 2 : 1 in all entries
                for(int i = 0; i < HardPoints.Count; i++) {
                    SpawnEnemy("hard", false, i);
                }

                tsSecondWave = true;
            }

            yield return ThirdStepSpawns();
        }
        else
        {
            // spawn 1 : on random entry every 13s
            SpawnEnemy("hard", true);
            
            yield return new WaitForSeconds(randomHardSpawnMin);

            yield return ThirdStepSpawns();
        }
    }

    void SpawnEnemy(string type, bool isRandom, int index = 0)
    {
        Transform entry;
        GameObject prefab;
        switch(type) {
            case "hard":
                entry = isRandom ? HardPoints[random.Next(HardPoints.Count)] : HardPoints[index];
                prefab = HardEnemyPrefab;
                break;
            case "medium":
                entry = isRandom ? MediumPoints[random.Next(MediumPoints.Count)] : MediumPoints[index];
                prefab = MediumEnemyPrefab;
                break;
            default:
                entry = isRandom ? BasicPoints[random.Next(BasicPoints.Count)] : BasicPoints[index];
                prefab = BasicEnemyPrefab;
                break;
        }

        GameObject spawn = Instantiate(prefab, entry.position, Quaternion.identity);
        allEnemies.Add(spawn);

    }

    public void ResetBasicEnemyCount()
    {
        basicEnemyIndex = 0;
    }
}
