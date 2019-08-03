using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperDisableOnHit : MonoBehaviour
{
    public float disableTime = 2.0f;
    bool disabled = false;
    float disabledCount = 0.0f;

    private Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(disabled)
        {
            //Count
            disabledCount += Time.deltaTime;

            if(disabledCount >= disableTime)
            {
                disabled = false;
                ToggleCollider(true);
            }
        }
    }

    void ToggleCollider(bool isOn)
    {
        collider.enabled = isOn;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        disabled = true;
        ToggleCollider(false);
        disabledCount = 0.0f;
    }
}
