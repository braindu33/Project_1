using System;
using UnityEngine;
using UnityEngine.Events;

public class OpenInterface : MonoBehaviour
{
    [SerializeField] private int maxDistance;
    
    [SerializeField] private OpenInterface open;
    [SerializeField] private CraftFonction craft;
    private RaycastHit hit;

    public void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                open = hit.collider.GetComponent<OpenInterface>();

                if (open)
                {
                    Debug.Log("Third");
                    craft.Open();
                }
            }
        }
    }
}
