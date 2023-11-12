using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private int quantity = 5;
    [SerializeField] private GameObject prefab;

    private void Update()
    {
        
    }

    public void Spawn()
    {
        for(int i = 0; i < quantity; i++)
        {
            Instantiate(prefab, null).transform.position = transform.position + Vector3.up;
        }
    }
}
