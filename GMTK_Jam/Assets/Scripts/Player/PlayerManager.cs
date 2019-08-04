using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject playerToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    public void OnPlayerDestroy()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        //This does not destroy the old one
        GameObject go = Instantiate(playerToSpawn,this.transform);
        go.SetActive(true);
    }
}
