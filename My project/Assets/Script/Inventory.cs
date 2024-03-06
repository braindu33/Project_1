using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set;}
    
    public List<Resource> resources = new();
    
    [SerializeField] private int emptyHandAttackForce = 1;
    [SerializeField] private int emptyHandHarvestLevel= 1;
    
    [SerializeField] private int size = 4;
    private int _currentSlot = 0;
    private GameObject[] _slots;

    private int interfaceToOpen;
    private GameObject[] @interface;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        _slots = new GameObject[size];
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

    public bool TrySetItemInEmptySlot(GameObject item)
    {
        if (_slots[_currentSlot])
            return false;

        _slots[_currentSlot] = item;
        return true;
    }
    
    public GameObject GetCurrentItem()
    {
        return _slots[_currentSlot];
    }

    public void RemoveCurrentSlot()
    {
        if (!_slots[_currentSlot])
            return;

        GameObject item = _slots[_currentSlot];
        _slots[_currentSlot] = null;
    }
}
