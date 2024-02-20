using System;
using UnityEngine;
using UnityEngine.Events;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private int maxLife = 100; // Maximum life points
    
    [SerializeField] private UnityEvent lifeReachedMin;
    
    private int _currentLife;   // Current life points

    void Start()
    {
        // Initialize the object's life points
        _currentLife = maxLife;
    }

    private void SetLife(int newLife)
    {
        // Set the object's life to a specific value
        _currentLife = Mathf.Clamp(newLife, 0, maxLife);

        // Optionally, you can perform actions based on the new life value
        if (_currentLife <= 0)
        {
            // Handle the object's death here
        }
    }

    public void Decrease(int damage)
    {
        _currentLife -= damage;

        // Check if the object's life has reached zero or less
        if (_currentLife <= 0)
        {
            // Handle the object's death (e.g., destroy the object)
            Destroy(gameObject);
            lifeReachedMin.Invoke();
        }
    }
}
