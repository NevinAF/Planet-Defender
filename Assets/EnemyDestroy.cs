﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.CompareTo("Bounds") == 0)
        {
            Destroy(gameObject);
        }
    }
}
