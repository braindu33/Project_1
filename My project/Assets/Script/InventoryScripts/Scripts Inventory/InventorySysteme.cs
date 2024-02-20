using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InventorySysteme : MonoBehaviour
{
    [SerializeField] private InventoryDisplay display;
    
    private InventoryData _data;

    public static InventorySysteme Instance { get; private set;}

    private void Awake()
    {
        var slotCount = display.Initialize(this);

        _data = new InventoryData(slotCount);

        display.UpdateDisplay(_data.Items);

        Instance = this;
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    public Resource AddItem(Resource item)
    {
        if (!_data.SlotAvailable(item)) return item;

        _data.AddItem(ref item);
        
        display.UpdateDisplay(_data.Items);

        return item;
    }

    public Resource PickItem(int slotID)
    {
        var result = _data.Pick(slotID);
        
        display.UpdateDisplay(_data.Items);

        return result;
    }

    public void SwapSlots(int slotA, int slotB)
    {
        _data.Swap(slotA, slotB);

        display.UpdateDisplay(_data.Items);
    }

    public Resource[] Data => _data.Items;
}