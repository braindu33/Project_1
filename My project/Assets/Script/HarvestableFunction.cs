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
    private Animator harvestAnimation;
    void Start()
    {
        life = GetComponent<LifeSystem>();
    }

    public void Harvest()
    {
        var inventory = Inventory.Instance;
        harvestAnimation = GetComponent<Animator>();

        if (inventory.GetPlayerHarvestLevel() < harvestLevelMin
            || inventory.GetPlayerHarvestCategories().Contains(harvestCategory))
        {
            life.Decrease(inventory.GetPlayerAttackForce());
            harvestAnimation.SetTrigger("Harvest");
        }
    }
}
