using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireRate = 1;
    public float bulletSpeed = 3;
    public float bulletMass = 1;
    public GameObject bullet;

    public float shootCount = 0;
	// Use this for initialization
	void Start ()
    {
        shootCount = fireRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(shootCount <= 0)
        {
            Fire();
            shootCount = fireRate;
        }
        else
        {
            shootCount -= Time.deltaTime;
        }
	}

    private void Fire()
    {
        Vector2 angle = new Vector2(
                -Mathf.Sin(Mathf.Deg2Rad * transform.localEulerAngles.z),
                Mathf.Cos(Mathf.Deg2Rad * transform.localEulerAngles.z)
                );
        GameObject go = GameObject.Instantiate(
            bullet,
            transform.position + new Vector3(angle.x, angle.y),
            transform.rotation);
        Rigidbody2D rigidbody = go.GetComponent<Rigidbody2D>();
        rigidbody.velocity = angle * bulletSpeed;
        rigidbody.mass = bulletMass;
    }
}
