using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Planet"))
        {
            other.GetComponent<PlanetBehaviour>().Boom();
            ScoreDisplay.instance.DestroyPlanet();
            Destroy(gameObject);
        }
        if (other.CompareTag("Ennemy"))
        {
            other.GetComponent<EnnemyBehaviour>().Boom();
            ScoreDisplay.instance.DestroyShip();
            Destroy(gameObject);
        }
    }
}
