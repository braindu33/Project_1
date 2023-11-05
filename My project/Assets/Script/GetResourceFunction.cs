using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetResourceFunction : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private int index;


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
        
                    Debug.Log("The resource is take");
                }
            }
        }
    }
}
