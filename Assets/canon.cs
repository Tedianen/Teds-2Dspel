using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform firePoint; 
    public float fireRate = 2f; 
    private float nextTimeToFire = 0f; 

    void Update()
    {
        // Automatically fire at intervals based on fireRate
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();
        }
    }

    void Fire()
    {
        // Instantiate the projectile at the fire point's position and rotation
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}

