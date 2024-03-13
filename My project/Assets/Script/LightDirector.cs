using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDirector : MonoBehaviour
{
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private Light sun;
    [SerializeField] private Light moon;

    private float moonMaxIntensity;
    private float sunMaxIntensity;
    private float rotX;

    private void Awake()
    {
        sunMaxIntensity = sun.intensity;
        moonMaxIntensity = moon.intensity;
        rotX = (360 / 24) * timeManager.CurrentTime;
    }

    private void Update()
    {
        UpdateLight(sun, rotX, sunMaxIntensity);
    }

    public void UpdateLight(Light light, float rotX, float maxIntensity)
    {
        rotX += 180;
        if (rotX < 360)
        {
            rotX -= 360;
        }
        UpdateLight(moon, rotX, moonMaxIntensity);
        
        light.transform.localEulerAngles = new Vector3(rotX, 0, 0);
        if (rotX < 90 || rotX > 270)
        {
            light.gameObject.SetActive(false);
        }
        else
        {
            light.gameObject.SetActive(true);

            if (rotX >= 90 && rotX < 180)
            {
                light.intensity = ((rotX - 90) / 90) * maxIntensity;
            }
            else if (rotX >= 180 && rotX < 270)
            {
                light.intensity = ((270 - rotX) / 90) * maxIntensity;
            }
        }
    }
}
