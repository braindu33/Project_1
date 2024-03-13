using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float timeSpeed;
    [SerializeField] private float startHour;
    
    private float currentTime;
    private int currentDay;

    public void Awake()
    {
        currentDay = 0;
        currentTime = startHour;
    }

    public void Update()
    {
        currentTime += Time.deltaTime * timeSpeed;

        if (currentTime > 24)
        {
            currentTime -= 24;
            currentDay++;
        }
    }

    public int CurrentDay => currentDay;
    public float CurrentTime => currentTime;
}
