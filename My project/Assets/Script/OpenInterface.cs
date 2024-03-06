using System;
using UnityEngine;
using UnityEngine.Events;

public class OpenInterface : MonoBehaviour
{
    //[SerializeField] private int maxDistance;
    
    [SerializeField] private OpenInterface openCraftInterface, openBuyInterface;
    [SerializeField] private CraftFonction craft;
    [SerializeField] private BuyabbleFonction buy;

    private RaycastHit hit;

    public void OpenCraftInterface()
    {        
        if (openCraftInterface)
        {
            craft.Open();
        }
        
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            openCraftInterface = hit.collider.GetComponent<OpenInterface>();

            if (openCraftInterface)
            {
                craft.Open();
            }
        }*/
    }
    
    public void OpenBuyInterface()
    {     
        if (openBuyInterface)
        {
            buy.Open();
        }
        
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            openBuyInterface = hit.collider.GetComponent<OpenInterface>();

            if (openBuyInterface)
            {
                buy.Open();
            }
        }*/
    }
}