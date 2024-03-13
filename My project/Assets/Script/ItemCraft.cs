using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemCraft
{
    [SerializeField] private int xpCount;
    [SerializeField] public int woodIndex, rockIndex;
    [SerializeField] public int woodCount = 1;
    [SerializeField] public int brickCount = 3;

    [SerializeField] public Vector3 positionSpawn;

    [SerializeField] public Button craftButton;
    
    public Spawner spawner;

    public void Craft()
    {
        if (Inventory.Instance.RemoveResource(woodIndex & rockIndex, woodCount & brickCount))
        {
            spawner.Spawn(positionSpawn);
            XpFunction.Instance.AddXp(xpCount);
        }
    }
}
