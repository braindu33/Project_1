using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    public static InventoryUIController Instance { get; private set;}
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateInventoryUI()
    {
        
    }
}
