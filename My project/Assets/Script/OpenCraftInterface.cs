using System;
using UnityEngine;
using UnityEngine.Events;

public class OpenCraftInterface : MonoBehaviour
{
    [SerializeField] private int maxDistanceToOpen;
    [SerializeField] private OpenCraftInterface openCraftInterface;
    [SerializeField] private CraftFonction craft;

    private RaycastHit hit;

    public void OpenInterfaceCraft()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, maxDistanceToOpen))
        {
            openCraftInterface = hit.collider.GetComponent<OpenCraftInterface>();
            if (openCraftInterface)
            {
                craft.Open();
            }
        }
    }
}   