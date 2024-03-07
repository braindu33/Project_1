using System;
using UnityEngine;

public class OpenBuyInterface : MonoBehaviour
{
    [SerializeField] private int maxDistanceToOpen;
    [SerializeField] private OpenBuyInterface openBuyInterface;
    [SerializeField] private BuyabbleFonction buy;

    private RaycastHit hit;

    public void OpenInterfaceBuy()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, maxDistanceToOpen))
        {
            openBuyInterface = hit.collider.GetComponent<OpenBuyInterface>();
            if (openBuyInterface)
            {
                buy.Open();
            }
        }
    }
}