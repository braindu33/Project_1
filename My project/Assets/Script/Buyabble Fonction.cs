using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

[RequireComponent(typeof(Spawner))]
public class BuyabbleFonction : MonoBehaviour
{
    //public List<Resource> PriceAndIndex = new();
    
    [SerializeField] private int itemPrice = 1;
    [SerializeField] private int itemIndex = 0;
    [SerializeField] private TextMeshPro textComponent;
    [SerializeField] private Vector3 positionSpawn;

    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3))
            {
                // Check if the object hit has a "LifeSystem" component
                BuyabbleFonction buy = hit.collider.GetComponent<BuyabbleFonction>();

                Debug.Log(hit.collider.gameObject.name);
                if (buy && Inventory.Instance.RemoveResource(itemIndex, itemPrice))
                {
                    _spawner.Spawn(positionSpawn);
                }
            }
        }
    }

    private void Start()
    {
        textComponent.text = itemPrice + "wood";
    }
    
}
