using UnityEngine;

public class Parchment : ItemData, IUsable
{
    [SerializeField] private string text;
    
    void IUsable.OnUse(InventoryContent ctx)
    {
        Debug.Log(text);  
    }
}