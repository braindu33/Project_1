using System;
using UnityEngine;
using UnityEngine.Events;

public class OpenInterface : MonoBehaviour
{
    [SerializeField] private int maxDistance;
    
    [SerializeField] private OpenInterface openCraftInterface, openBuyInterface;
    [SerializeField] private CraftFonction craft;
    [SerializeField] private BuyabbleFunction buy;

    private RaycastHit hit;

    public void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                openCraftInterface = hit.collider.GetComponent<OpenInterface>();

                if (openCraftInterface)
                {
                    craft.Open();
                }

                openBuyInterface = hit.collider.GetComponent<OpenInterface>();

                if (openBuyInterface)
                {
                    buy.Open();
                }
            }
        }
    }
}
