using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public bool IsBasic;

    public bool IsMedium;

    public float Speed;

    public int points;

    private bool MediumAlreadyHit;

    public Transform target;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (GameObject.Find("PlayerTarget"))
        {
            target = GameObject.Find("PlayerTarget").transform;
        }
    }

    private void OnDestroy()
    {
        if(IsBasic)
            GameManager.GetInstance().IncreaseBasicEnemeiesDefeated();
        if (IsMedium)
            GameManager.GetInstance().IncreaseMediumEnemeiesDefeated();

        GameManager.GetInstance().IncreaseScore(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), points);
        //Debug.Log("basic : " + GameManager.GetInstance().GetBasicEnemeiesDefeated());
        //Debug.Log("medium : " + GameManager.GetInstance().GetMediumEnemeiesDefeated());
    }

    private void Update()
    {
        Vector2 differenceNormalized = (target.position - transform.position).normalized;
        rb.velocity = differenceNormalized * Speed;
    }
}
