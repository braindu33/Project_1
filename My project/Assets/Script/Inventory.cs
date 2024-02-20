using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Resource> resources = new();
    
    public static Inventory Instance { get; private set;}

    [SerializeField] private int emptyHandAttackForce = 1;
    [SerializeField] private int emptyHandHarvestLevel= 1;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    
    public int GetPlayerAttackForce()
    {
        var _pickableInHand = GetComponentInChildren<PickableFonction>();

        if(!_pickableInHand) return emptyHandAttackForce;
        return _pickableInHand.AttackForce;
    }

    public int GetPlayerHarvestLevel()
    {
        var _pickableInHand = GetComponentInChildren<PickableFonction>();

        if(!_pickableInHand) return emptyHandHarvestLevel;
        return _pickableInHand.HarvestLevel;
    }

    public string[] GetPlayerHarvestCategories()
    {
        var _pickableInHand = GetComponentInChildren<PickableFonction>();

        if(!_pickableInHand) return null;
        return _pickableInHand.HarvestCategories;
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
