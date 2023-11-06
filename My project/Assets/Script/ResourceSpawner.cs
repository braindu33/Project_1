using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private int quantity = 5;
    [SerializeField] private GameObject prefab;

    private GameObject _resource;
    private Health _health;

    private void Awake()
    {
        _health = gameObject.GetComponent<Health>();
        _resource = GameObject.FindGameObjectWithTag("Resource");
    }

    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (_health == null)
        {
            Destroy(gameObject);
        }
    }
}
