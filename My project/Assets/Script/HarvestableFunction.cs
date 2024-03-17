using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//[RequireComponent(typeof(Health))]
public class HarvestableFunction : MonoBehaviour
{
    [SerializeField] private string harvestCategory = "wood";
    [SerializeField] private int harvestLevelMin;
    
    private LifeSystem life;
    void Start()
    {
        life = GetComponent<LifeSystem>();
    }

    public void Harvest()
    {
        Inventory inventory = Inventory.Instance;

        if (inventory.GetPlayerHarvestLevel() >= harvestLevelMin 
            && inventory.GetPlayerHarvestCategories().Contains(harvestCategory))
        {
            life.Decrease(inventory.GetPlayerAttackForce());
        }
    }
}
