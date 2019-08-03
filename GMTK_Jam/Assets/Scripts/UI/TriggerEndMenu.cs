using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndMenu : MonoBehaviour
{
    public GameObject leaderboard;
    // Start is called before the first frame update
    void Start()
    {
        leaderboard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            leaderboard.SetActive(!leaderboard.activeSelf);
        }
    }
}
