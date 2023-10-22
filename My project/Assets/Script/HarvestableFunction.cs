using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class HarvestableFunction : MonoBehaviour
{
    private Health health;
    void Start()
    {
        health = GetComponent<Health>();
    }

    public void Harvest()
    {
        health.Decrease(1);
    }
    void Update()
    {
        
    }
}
