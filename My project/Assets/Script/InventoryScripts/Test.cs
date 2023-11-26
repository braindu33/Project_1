using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Item itemToPush, itemToPick;

    private InventorySysteme _inventory;

    private void Awake()
    {
        _inventory = FindObjectOfType<InventorySysteme>();
    }

    [ContextMenu("Test Push")]
    private void Add()
    {
        itemToPush = _inventory.AddItem(itemToPush);
    }

    [ContextMenu("Test Pick")]
    private void Pick()
    {
        itemToPick = _inventory.PickItem(1);
    }
}
