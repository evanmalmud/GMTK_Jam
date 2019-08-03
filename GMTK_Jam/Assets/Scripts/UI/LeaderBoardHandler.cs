using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardHandler : MonoBehaviour
{
    public GameObject EntryPrefab;

    public void addEntry(string rank, string name, string score) {
        (Instantiate(EntryPrefab, transform) as GameObject).GetComponent<LeaderBoardEntry>().SetInfos(rank, name, score);
    }

    public void ClearEntries() {
        for(int i=transform.childCount-1;i>=0;i--){
            Destroy (transform.GetChild(i).gameObject);
        }
    }
}
