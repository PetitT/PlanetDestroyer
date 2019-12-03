using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetBehaviour : MonoBehaviour, IExplodable
{
    public Vector2 scale;
    public GameObject explosion;
    public GameObject anneau;
    private float scaleVector;

    private void Start()
    {
        GetRandomScale();
        RandomizeColors();
        DisplayAnneau();
    }

    private void DisplayAnneau()
    {
        int display = UnityEngine.Random.Range(0, 2);
        if (display == 0)
            anneau.SetActive(true);
        else
            anneau.SetActive(false);
    }

    private void RandomizeColors()
    {
        foreach (var mat in GetComponentsInChildren<MeshRenderer>())
        {
            mat.material.color = Random.ColorHSV();
        }
    }

    private void GetRandomScale()
    {
        scaleVector = Random.Range(scale.x, scale.y);
        gameObject.transform.localScale = new Vector3(scaleVector, scaleVector, scaleVector);
    }

    public void Boom()
    {
        Destroy(gameObject);
        GameObject explo = Instantiate(explosion, transform.position, transform.rotation);
        explo.transform.localScale = new Vector3(scaleVector, scaleVector, scaleVector);
        Destroy(explo, 3f);
    }
}
