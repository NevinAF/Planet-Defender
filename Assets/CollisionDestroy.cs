using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
