using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour, IExplodable
{
    private GameObject player;
    public float maxDistanceDelta;
    public float shootTimer;
    public GameObject projectile;
    public Transform shootPos;
    private float remainingShootTimer;
    public float speed;
    public GameObject explosion;
    private bool isMoving;
    public float maxDistanceFromPlayer;

    private void Start()
    {
        player = FindObjectOfType<Movement>().gameObject;
        remainingShootTimer = shootTimer;
    }

    private void Update()
    {
        transform.LookAt(player.transform);

        if (isMoving)
            FollowPlayer();

        CheckDistance();
        ShootCountDown();
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= maxDistanceFromPlayer)
            isMoving = false;
        else
            isMoving = true;
    }

    private void ShootCountDown()
    {
        remainingShootTimer -= Time.deltaTime;
        if (remainingShootTimer <= 0)
        {
            PewPew();
            remainingShootTimer = shootTimer;
        }
    }

    private void PewPew()
    {
        GameObject newProjectile = Instantiate(projectile, shootPos.position, transform.rotation);
        Destroy(newProjectile, 3f);
    }

    private void FollowPlayer()
    {
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Boom()
    {
        GameObject boom = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(boom, 2);
        Destroy(gameObject);
    }
}
