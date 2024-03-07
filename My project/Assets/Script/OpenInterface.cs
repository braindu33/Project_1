using System;
using UnityEngine;
using UnityEngine.Events;

public class OpenCraftInterface : MonoBehaviour
{
    [SerializeField] private OpenCraftInterface openCraftInterface;
    [SerializeField] private CraftFonction craft;

    private RaycastHit hit;

    public void OpenInterfaceCraft()
    {        
        if (openCraftInterface)
        {
            craft.Open();
        }
    }
}

public class OpenBuyInterface : MonoBehaviour
{
    [SerializeField] private OpenBuyInterface openBuyInterface;
    [SerializeField] private BuyabbleFonction buy;

    private RaycastHit hit;
    
    public void OpenInterfaceBuy()
    {     
        if (openBuyInterface)
        {
            buy.Open();
        }
    }
}