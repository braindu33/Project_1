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
        if (Camera.main == null) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out hit, maxDistanceToOpen)) return;
        
        openBuyInterface = hit.collider.GetComponent<OpenBuyInterface>();
        if (openBuyInterface)
        {
            buy.Open();
        }
    }
}