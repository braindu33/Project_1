using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private int quantity;
    [SerializeField] private GameObject prefab;
    

    public void Spawn()
    {
        for(var i = 0; i < quantity; i++)
        {
            Instantiate(prefab, null).transform.position = transform.position + Vector3.up;
        }
    }
}
