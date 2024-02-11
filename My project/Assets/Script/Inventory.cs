using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Resource> resources = new();
    
    public static Inventory Instance { get; private set;}

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public Resource GetResource(int index)
    {
        return resources[index];
    }
    
    public bool RemoveResource(int index, int resourceToRemove)
    {
        return resources[index].RemoveResource(resourceToRemove);
    }
}
