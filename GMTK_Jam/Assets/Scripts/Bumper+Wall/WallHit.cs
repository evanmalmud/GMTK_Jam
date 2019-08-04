using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WallHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        AudioManager.instance.Play("Wall Hit");
    }
}
