using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class Resource
{
    [SerializeField] private int index;
    [SerializeField] private int maxValue = 0;
    [SerializeField] private int value;


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
}
