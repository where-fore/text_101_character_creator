﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private float startingIntensity = 0f;
    [SerializeField] private float intensityDeltaRange = 0.05f;
    [SerializeField] private float flickerDelayBase = 0.075f;
    [SerializeField] private float flickerDelayRange = 0.005f;
    [SerializeField] private bool flickering = true;
    private Light myLightComponent = null;

    void Start()
    {
        myLightComponent = GetComponent<Light>();
        startingIntensity = myLightComponent.intensity;

        StartCoroutine(FlickerCycle());
    }

    private IEnumerator FlickerCycle()
    {
        while (flickering)
        {
            float delay = flickerDelayBase + Random.Range(-flickerDelayRange, flickerDelayRange);
            delay = Mathf.Clamp(delay, 0f, 1f); // to ensure you don't accidently type in 5sec+ and have to wait for it to reset
            yield return new WaitForSeconds(delay);
            ChangeIntensity();
        }
    }

    private void ChangeIntensity()
    {
        float intensityDelta = Random.Range(-intensityDeltaRange, intensityDeltaRange);
        myLightComponent.intensity = startingIntensity + intensityDelta;
    }
}