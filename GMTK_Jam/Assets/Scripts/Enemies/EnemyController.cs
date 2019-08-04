using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public bool IsBasic;

    public bool IsMedium;

    public float Speed;

    private bool MediumAlreadyHit;

    public Transform target;

    private Rigidbody2D rb;

    Animator animator;

    public int deathLength = 3;

    public int playerDeathLength = 1;

    private bool moving = true;

    private void Start()
    {
        animator = gameObject.GetComponentInParent<Animator>();
        animator.SetBool("Walking", true);
        rb = GetComponent<Rigidbody2D>();
        
        if (GameObject.Find("PlayerTarget"))
        {
            target = GameObject.Find("PlayerTarget").transform;
        }
    }

    public void KillEnemy()
    {
        //Disable RigidBodies and Colliders
        Collider2D collid = GetComponent<Collider2D>();
        collid.enabled = false;
        
        if(IsBasic)
            GameManager.GetInstance().IncreaseBasicEnemeiesDefeated();
        if (IsMedium)
            GameManager.GetInstance().IncreaseMediumEnemeiesDefeated();

        StartCoroutine(DestroyEnemy());
        //Debug.Log("basic : " + GameManager.GetInstance().GetBasicEnemeiesDefeated());
        //Debug.Log("medium : " + GameManager.GetInstance().GetMediumEnemeiesDefeated());
    }

    public void KillPlayer()
    {
        StartCoroutine(DestroyPlayer());
    }

    private void Update()
    {
        if(moving)
        {
            Vector2 differenceNormalized = (target.position - transform.position).normalized;
            rb.velocity = differenceNormalized * Speed;
        }

    }

    private IEnumerator DestroyEnemy()
    {
        animator.SetBool("Walking", false);
        animator.SetTrigger("Die");

        yield return new WaitForSeconds(deathLength);

        Destroy(transform.parent.gameObject);
        yield return null;
    }

    private IEnumerator DestroyPlayer()
    {
        //Stop Movement
        moving = false;
        rb.velocity = Vector2.zero;

        animator.SetBool("Walking", false);
        animator.SetTrigger("Game Over");
        GameObject.FindObjectOfType<MenuController>().EndGameSounds();

        yield return new WaitForSeconds(playerDeathLength);

        GameObject.FindObjectOfType<MenuController>().EndGame();
        GameManager.GetInstance().EndGame();
        yield return null;
    }
}
