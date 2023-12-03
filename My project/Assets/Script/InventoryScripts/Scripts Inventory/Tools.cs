using UnityEngine;

public class Tools : ItemData, IUsable, IEquipable, IDurable
{
    [SerializeField] private int durability;
    
    public void OnBreak(InventoryContent ctx)
    {
        Debug.Log("Break");
    }

    public void OnEquipped(InventoryContent ctx)
    {
        Debug.Log("Equipped");
    }

    public void OnRepair(InventoryContent ctx)
    {
        Debug.Log("Repaired");
    }

    public void OnUse(InventoryContent ctx)
    {
        Debug.Log("Attack");
    }
    
    int IDurable.MaxDurability => durability;
}