using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetResourceFunction : MonoBehaviour
{
    public static GetResourceFunction Instance { get; private set;}
    
    [SerializeField] private int value;
    [SerializeField] private int index;
    [SerializeField] private int xpIndex;
    [SerializeField] private int xpValue;

    /*[SerializeField] private string[] getTagCategory; 
    public string[] GetCategory => getTagCategory;*/
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void GetResource()
    {
        Inventory.Instance.GetResource(index).AddResource(value);
        Inventory.Instance.GetXp(xpIndex).AddXp(xpValue);
        Destroy(gameObject);
    }
}
