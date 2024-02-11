using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Resource
{
    public static Resource Instance { get; private set;}
    
    [SerializeField] private int index;
    [SerializeField] private int maxValue = 0;
    [SerializeField] private int value;
    [SerializeField] private int count;
    
    private ResourceData _data;


    public void AddResource(int resourceToAdd)
    {
        value += resourceToAdd;

        if (value > maxValue)
            value = maxValue;
       
        ResourceUIController.Instance.UpdateResourceUI(index, value);
    }

    public bool RemoveResource(int resourceToRemove)
    {
        if (value - resourceToRemove < 0)
            return false;

        value -= resourceToRemove;
        ResourceUIController.Instance.UpdateResourceUI(index, value);
        return true;
    }
    
    public void Merge(ref Resource other)
    {
        if (Full) return;

        if (Empty) _data = other._data;

        if (other.Data != _data) throw new System.Exception("Try to merge different types items.");

        int total = other.count + count;

        if (total <= _data.stackMaxCount)
        {
            count = total;
            other.count = 0;
            return;
        }

        count = _data.stackMaxCount;
        other.count = total - count;
    }
    public bool AvailableFor(Resource other) => Empty || (Data == other._data && !Full);
    
    public ResourceData Data => _data;

    public bool Full => _data && count >= _data.stackMaxCount;
    public bool Empty => count == 0 || _data == null;

    public int Count => count;
}
