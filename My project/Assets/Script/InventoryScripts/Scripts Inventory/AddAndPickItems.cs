using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAndPickItems : MonoBehaviour
{
    private Item _itemToPush, _pickedItem;

    private InventorySysteme _inventory;

    private void Awake()
    {
        _inventory = FindObjectOfType<InventorySysteme>();
    }

    private void Add()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _itemToPush = _inventory.AddItem(_itemToPush);
        }
    }

    private void Pick()
    {
        
    }
}
