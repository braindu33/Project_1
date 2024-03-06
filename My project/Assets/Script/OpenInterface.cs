using System;
using UnityEngine;
using UnityEngine.Events;

public class OpenCraftInterface : MonoBehaviour
{
    [SerializeField] private OpenCraftInterface openCraftInterface;
    [SerializeField] private CraftFonction craft;

    private RaycastHit hit;

    public void OpenCraftInterface()
    {        
        if (openCraftInterface)
        {
            craft.Open();
        }
    }
}

public class OpenBuyInterface : MonoBehaviour
{
    [SerializeField] private OpenInterface openBuyInterface;
    [SerializeField] private BuyabbleFonction buy;

    private RaycastHit hit;
    
    public void OpenBuyInterface()
    {     
        if (openBuyInterface)
        {
            buy.Open();
        }
    }
}