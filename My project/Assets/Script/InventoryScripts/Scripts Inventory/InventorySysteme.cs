using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector.Editor.Drawers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class InventorySysteme : MonoBehaviour
{
    [SerializeField] private InventoryDisplay display;
    
    private InventoryData _data;

    private void Awake()
    {
        int slotCount = display.Initialize();

        _data = new InventoryData(slotCount);

        display.UpdateDisplay(_data.items);
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    public Item AddItem(Item item)
    {
        if (!_data.SlotAvailable(item)) return item;

        _data.AddItem(ref item);
        
        display.UpdateDisplay(_data.items);

        return item;
    }

    public Item PickItem(int slotID)
    {
        Item result = _data.Pick(slotID);
        
        display.UpdateDisplay(_data.items);

        return result;
    }
}