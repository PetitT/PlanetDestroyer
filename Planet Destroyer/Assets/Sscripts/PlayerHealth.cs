using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PostProcessVolume ppv;
    private Vignette vignette;
    private float currentHealth = 1;
    public float healthToGainPerSecond;
    public float healthLostPerDamage;

    private void Start()
    {
        ppv.profile.TryGetSettings(out vignette);
    }

    private void Update()
    {
        ShowVignette();
        RegainHealth();
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (currentHealth >= 1)
            currentHealth = 1;

        if (currentHealth <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void RegainHealth()
    {
        currentHealth += healthToGainPerSecond * Time.deltaTime;

    }

    private void ShowVignette()
    {
        vignette.intensity.value = 1 - currentHealth;
    }

    public void LoseHealth()
    {
        currentHealth -= healthLostPerDamage;
    }
}
