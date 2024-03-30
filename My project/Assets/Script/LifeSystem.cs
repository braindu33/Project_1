using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private int maxLife = 100; // Maximum life points
    
    [SerializeField] private UnityEvent lifeReachedMin;
    
    private GameObject rock;
    
    private int currentLife; // Current life points
    private RaycastHit hit;


    private void Awake()
    {
    }

    void Start()
    {
        // Initialize the object's life points
        currentLife = maxLife;
    }

    private void SetLife(int newLife)
    {
        // Set the object's life to a specific value
        currentLife = Mathf.Clamp(newLife, 0, maxLife);

        // Optionally, you can perform actions based on the new life value
        if (currentLife <= 0)
        {
            // Handle the object's death here
        }
    }

    public void Decrease(int damage)
    {
        currentLife -= damage;

        // Check if the object's life has reached zero or less
        if (currentLife <= 0) return;
        Destroy(gameObject);
        lifeReachedMin.Invoke();
    }
}
