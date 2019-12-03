using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyProjectile : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.GetComponent<PlayerHealth>().LoseHealth();
        }
        if (other.CompareTag("Planet"))
        {
            Destroy(gameObject);
            other.GetComponent<PlanetBehaviour>().Boom();
        }
    }
}
