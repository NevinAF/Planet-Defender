using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [System.NonSerialized] private static float score = 0;
    
    public GameObject Endscreen;
    public TimeKeeper Timer;
    public TextMeshProUGUI text;

    private void Start()
    {
        text.text = "\n\rHighScore: " + score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (Rigidbody2D rb in GameObject.FindObjectsOfType<Rigidbody2D>())
        {
            AddExplosionForce(rb, 5, Vector3.zero, 8);
        }

        Destroy(gameObject);
        GameObject.FindObjectOfType<EnemySpawner>().enabled = false;
        Endscreen.SetActive(true);
        
        if(score < Timer.GetTime())
        {
            score = Timer.GetTime();
            text.text = "\n\rHighScore: " + score;
        }
        Timer.enabled = false;
    }

    public static void AddExplosionForce(Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius)
    {
        var dir = (body.transform.position - explosionPosition);
        float wearoff = 1 - (dir.magnitude / explosionRadius);
        body.AddForce(dir.normalized * explosionForce * wearoff);
    }
}
