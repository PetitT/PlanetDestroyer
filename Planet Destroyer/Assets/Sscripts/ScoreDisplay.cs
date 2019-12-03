using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public static ScoreDisplay instance;
    private float score = 0;
    public float scorePerSecond;
    public float scorePerPlanetDestroyed;
    public float scorePerShipDestroyed;
    public TextMeshPro text;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    private void Update()
    {
        GainScore();
        UpdateText();
    }

    private void GainScore()
    {
        score += scorePerSecond * Time.deltaTime;
    }

    private void UpdateText()
    {
        int currentScore = (int)score;
        text.text = currentScore.ToString();
    }

    public void DestroyShip()
    {
        score += scorePerShipDestroyed;
    }

    public void DestroyPlanet()
    {
        score += scorePerPlanetDestroyed;
    }
}
