using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class XpFunction 
{
    public static XpFunction Instance { get; private set;}

    [SerializeField] private int maxValue;
    [SerializeField] private int xpIndex;
    [SerializeField] private int value;
    
    
    public void AddXp(int xpToAdd)
    {
        value += xpToAdd;

        if (value > maxValue)
            value = maxValue;
        
        ResourceUIController.Instance.UpdateXpUI(xpIndex, value);
    }

    
    public bool RemoveXp(int xpRemove)
    {
        if (value - xpRemove < 0)
            return false;

        value -= xpRemove; 
        ResourceUIController.Instance.UpdateXpUI(xpIndex, value);
        return true;
    }

    public bool GetCount => value == 60;
}