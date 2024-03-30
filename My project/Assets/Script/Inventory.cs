using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set;}
    
    public List<Resource> resources = new();
    public List<XpFunction> xp = new();
    
    [SerializeField] private int emptyHandAttackForce = 1;
    [SerializeField] private int emptyHandHarvestLevel= 1;
    
    [SerializeField] private int size = 4;
    private int currentSlot = 0;
    private GameObject[] slots;

    private int interfaceToOpen;
    private GameObject[] @interface;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        slots = new GameObject[size];
    }
    
    public int GetPlayerAttackForce()
    {
        var pickableInHand = GetComponentInChildren<PickableFonction>();

        return !pickableInHand ? emptyHandAttackForce : pickableInHand.AttackForce;
    }

    public int GetPlayerHarvestLevel()
    {
        var pickableInHand = GetComponentInChildren<PickableFonction>();

        return !pickableInHand ? emptyHandHarvestLevel : pickableInHand.HarvestLevel;
    }

    public string[] GetPlayerHarvestCategories()
    {
        var pickableInHand = GetComponentInChildren<PickableFonction>();

        return !pickableInHand ? null : pickableInHand.HarvestCategories;
    }

    public Resource GetResource(int index)
    {
        return resources[index];
    }
    
    public bool RemoveResource(int index, int resourceToRemove)
    {
        return resources[index].RemoveResource(resourceToRemove);
    }

    public XpFunction GetXp(int xpIndex)
    {
        return xp[xpIndex];
    }

    public bool RemoveXp(int index, int value)
    {
        return xp[index].RemoveXp(value);
    }

    public bool GetXpCount(int index)
    {
        return xp[index].GetCount;
    }

    public bool TrySetItemInEmptySlot(GameObject item)
    {
        if (slots[currentSlot])
            return false;

        slots[currentSlot] = item;
        return true;
    }
    
    public GameObject GetCurrentItem()
    {
        return slots[currentSlot];
    }

    public void RemoveCurrentSlot()
    {
        if (!slots[currentSlot])
            return;

        GameObject item = slots[currentSlot];
        slots[currentSlot] = null;
    }
    
    public void Select(int slot)
    {
        if (slot >= size)
        {
            slot = 0;
        }else if (slot < 0)
        {
            slot = size - 1;
        }

        if (slot == currentSlot) return;

        GameObject currentInteractable = GetCurrentItem();
        if (currentInteractable)
            currentInteractable.SetActive(false);

        currentSlot = slot;
        
        currentInteractable = GetCurrentItem();
        if (currentInteractable)
            currentInteractable.SetActive(true);
    }

    public void NextSlot()
    {
        Select(currentSlot + 1);
    }

    public void PreviousSlot()
    {
        Select(currentSlot - 1);
    }
}
