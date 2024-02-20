using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private int emptyHandAttackForce = 1;
    [SerializeField] private int emptyHandHarvestLevel= 1;

    [SerializeField] private int size = 4;
    private int _currentSlot = 0;
    private GameObject[] _slots;

    public static InventorySystem Instance { get; private set;}

    void Awake()
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

    public bool IsHandFull()
    {
        var _pickableInHand = GetComponentInChildren<PickableFonction>();

        if(!_pickableInHand) return false;
        return true;
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

        if (slot == _currentSlot) return;

        GameObject currentInteractable = GetCurrentItem();
        if (currentInteractable)
            currentInteractable.SetActive(false);

        _currentSlot = slot;
        
        currentInteractable = GetCurrentItem();
        if (currentInteractable)
            currentInteractable.SetActive(true);
    }

    public void NextSlot()
    {
        Select(_currentSlot + 1);
    }

    public void PreviousSlot()
    {
        Select(_currentSlot - 1);
    }

    public GameObject GetCurrentItem()
    {
        return _slots[_currentSlot];
    }

    public bool TrySetItemInEmptySlot(GameObject item)
    {
        if (_slots[_currentSlot])
            return false;

        _slots[_currentSlot] = item;
        return true;
    }
    
    public void RemoveCurrentSlot()
    {
        if (!_slots[_currentSlot])
            return;

        GameObject item = _slots[_currentSlot];
        _slots[_currentSlot] = null;
    }
}
