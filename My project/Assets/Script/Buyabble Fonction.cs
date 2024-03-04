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

    private void Start()
    {
        textComponent.text = itemPrice + "wood";
    }

    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3))
        {
            BuyabbleFonction buy = hit.collider.GetComponent<BuyabbleFonction>();
            if (buy && Inventory.Instance.RemoveResource(itemIndex, itemPrice))
            {
                _spawner.Spawn(positionSpawn);
            }
        }
    }
    
}
