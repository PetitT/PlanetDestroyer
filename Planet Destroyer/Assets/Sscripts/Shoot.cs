using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePos;
    public Animator anim;
    public AudioSource source;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newProjectile = Instantiate(projectile, projectilePos.position, projectilePos.rotation);
            Destroy(newProjectile, 5);
            anim.SetTrigger("Shoot");
            source.Play();
        }
    }
}
