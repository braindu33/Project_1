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

    private int clickCount = 0;
    
    private static readonly int HarvestWood = Animator.StringToHash("Harvest");
    
    private static readonly int ShakeStep1 = Animator.StringToHash("First Shake");
    private static readonly int ShakeStep2 = Animator.StringToHash("Second Shake");
    private static readonly int ShakeStep3 = Animator.StringToHash("Third Shake");
    private static readonly int ShakeFinalStep = Animator.StringToHash("Final Shake");
    

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
        //clickCount++;
        var inventory = Inventory.Instance;
        harvestAnimation = GetComponentInChildren<Animator>();
        
        if(inventory.GetPlayerHarvestLevel() >= harvestLevelMin && !inventory.GetPlayerHarvestCategories().Contains(harvestCategory)) return;
        
        life.Decrease(inventory.GetPlayerAttackForce());
        
        /*switch (clickCount)
        {
            case 1:
                harvestAnimation.SetTrigger(ShakeStep1);
                break;
            case 2:
                harvestAnimation.SetTrigger(ShakeStep2);
                break;
            case 3:
                harvestAnimation.SetTrigger(ShakeStep3);
                break;
            case 4:
                harvestAnimation.SetTrigger(ShakeFinalStep);
                break;
        }*/
    }
}
