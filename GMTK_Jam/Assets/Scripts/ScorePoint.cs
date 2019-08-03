using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePoint : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetTextAndDestroy(int points) {
        GetComponent<TextMeshPro>().text = points.ToString();

        StartCoroutine("WaitAndDestroy");
    }
    
    IEnumerator WaitAndDestroy() {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
