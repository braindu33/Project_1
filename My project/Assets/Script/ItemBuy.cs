using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemBuy
{
    [SerializeField] public int woodIndex;
    [SerializeField] public int woodCount = 50;
    [SerializeField] public Vector3 positionSpawn;
    [SerializeField] public Button buyButton;
    [SerializeField] public Button closeButton;
    
    public Spawner spawner;
    
    public void Buy()
    {
        if (Inventory.Instance.RemoveResource(woodIndex, woodCount)) 
        { 
            spawner.Spawn(positionSpawn);
        }
    }
}