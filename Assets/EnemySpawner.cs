using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public const float MaxMass = 5f;
    public const float MinMass = 0.8f;

    public float spawnRate = 1;
    public float speed = 1;
    public float mass = 1;
    public float difUpTime;
    [Range(0, .99f)]
    public float difUpPercent = .70f;
    public GameObject enemyPrefab;

    private float shootCount = 0;
    private float timer;
    // Use this for initialization
    void Start()
    {
        shootCount = spawnRate;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCount <= 0)
        {
            SpawnEnemy();
            shootCount = spawnRate;
        }
        else
        {
            shootCount -= Time.deltaTime;
        }

        timer += Time.deltaTime;

        if(timer > difUpTime)
        {
            timer = 0;
            if(speed < mass)
            {
                speed *= 1 + difUpPercent;
                spawnRate *= 1 - difUpPercent;
            }
            else
            {
                mass *= 1 + (difUpPercent);
            }
        }
    }

    private void SpawnEnemy()
    {
        float randAngle = UnityEngine.Random.value * 360f;
        GameObject go = Instantiate(enemyPrefab);

        Vector2 inwardDirection = new Vector2(
                -Mathf.Sin(Mathf.Deg2Rad * randAngle),
                Mathf.Cos(Mathf.Deg2Rad * randAngle)
                );
        
        go.transform.position = new Vector3(-inwardDirection.x * 10, -inwardDirection.y * 10);

        Rigidbody2D rigidbody = go.GetComponent<Rigidbody2D>();
        rigidbody.velocity = inwardDirection * speed;

        float go_mass = UnityEngine.Random.value * mass;
        go_mass = Mathf.Clamp(go_mass, MinMass, MaxMass);

        rigidbody.mass = mass;

        Debug.Log(go_mass);

        go.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.black, go_mass/MaxMass);
    }
}
