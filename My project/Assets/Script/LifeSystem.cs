using System;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField]
    private int maxLife = 100; // Maximum life points
    private int currentLife;   // Current life points

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

    public void TakeDamage(int damage)
    {
        currentLife -= damage;

        // Check if the object's life has reached zero or less
        if (currentLife <= 0)
        {
            // Handle the object's death (e.g., destroy the object)
            Destroy(gameObject);
        }
    }
}
