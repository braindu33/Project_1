using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DamageFunction : MonoBehaviour
{
    [SerializeField] private int attackRange = 5;
    [SerializeField] private int attackForce = 2;
    
    private Health _health;
    private GameObject _player;

    void Awake()
    {
        _health = _player.GetComponent<Health>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Damage()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) <= attackRange)
        {
            _health.Decrease(attackForce);
        }
    }
}
