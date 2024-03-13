using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemBuy
{
    [SerializeField] private int xpCount;
    [SerializeField] public int woodIndex;
    [SerializeField] public int woodCount = 50;
    [SerializeField] public Vector3 positionSpawn;
    [SerializeField] public Button buyButton;
    public Spawner spawner;
    
    public void Buy()
    {
        if (Inventory.Instance.RemoveResource(woodIndex, woodCount)) 
        { 
            spawner.Spawn(positionSpawn);
            XpFunction.Instance.AddXp(xpCount);
        }
    }
}