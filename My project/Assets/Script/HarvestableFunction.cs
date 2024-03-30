using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//[RequireComponent(typeof(Health))]
public class HarvestableFunction : MonoBehaviour
{
    [SerializeField] private string harvestCategory;
    [SerializeField] private int harvestLevelMin;
    
    private LifeSystem life;
    private Animator harvestAnimation;
    
    private static readonly int HarvestWood = Animator.StringToHash("Harvest");
    private static readonly int HarvestBrick = Animator.StringToHash("Harvest Rock");
    
    

    void Start()
    {
        life = GetComponent<LifeSystem>();
    }

    public void HarvestTree()
    {
        var inventory = Inventory.Instance;
        harvestAnimation = GetComponentInChildren<Animator>();

        if (inventory.GetPlayerHarvestLevel() >= harvestLevelMin
            && !inventory.GetPlayerHarvestCategories().Contains(harvestCategory)) return;
        
        life.Decrease(inventory.GetPlayerAttackForce());
        harvestAnimation.SetTrigger(HarvestWood);
    }

    public void HarvestRock()
    {
        var inventory = Inventory.Instance;
        harvestAnimation = GetComponentInChildren<Animator>();
        
        if(inventory.GetPlayerHarvestLevel() >= harvestLevelMin 
           && !inventory.GetPlayerHarvestCategories().Contains(harvestCategory)) return;

        life.Decrease(inventory.GetPlayerAttackForce());
        harvestAnimation.SetTrigger(HarvestBrick);
    }
}
