using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetResourceFunction : MonoBehaviour
{
    public static GetResourceFunction Instance { get; private set;}
    
    public List<IndexRepository> indexRepositories = new();
    
    [SerializeField] private int value;
    [SerializeField] private int index;

    private Actionable _objectTaked;


    /*public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3))
            {
                GetResourceFunction getResourceFunction = hit.collider.GetComponent<GetResourceFunction>();

                if (getResourceFunction == this)
                {
                    Inventory.Instance.GetResource(index).AddResource(value);
                    Destroy(gameObject);
                }
            }
        }
    }*/
    
    //[ContextMenu("Prendre")]
    public void GetResource()
    {
        Inventory.Instance.GetResource(index).AddResource(value);
        Destroy(gameObject);
        
        Debug.Log("La ressource est collectée");
    }
}
