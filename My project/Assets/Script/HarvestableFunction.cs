using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//[RequireComponent(typeof(Health))]
public class HarvestableFunction : MonoBehaviour
{
    [SerializeField] private string harvestCategory = "wood";
    [SerializeField] private int harvestLevelMin = 5;
    
    private Health health;
    void Start()
    {
        health = GetComponent<Health>();
    }

    public void Harvest()
    {
        Inventory inventory = Inventory.Instance;

        if (inventory.GetPlayerHarvestLevel() >= harvestLevelMin 
            && inventory.GetPlayerHarvestCategories().Contains(harvestCategory))
        {
            health.Decrease(inventory.GetPlayerAttackForce());
        }
    }
}
