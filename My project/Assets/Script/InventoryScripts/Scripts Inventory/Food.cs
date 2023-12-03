using UnityEngine;

public class Food : ItemData, IConsumable
{
    [SerializeField] private int feedingFactor = 1;
    
    void IConsumable.OnConsume(InventoryContent ctx)
    {
        Debug.Log("Feed =" + feedingFactor);
    }
}