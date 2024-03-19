using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickableFonction : MonoBehaviour
{
    [SerializeField] private Vector3 pickupPosition;
    [SerializeField] private Quaternion pickupRotation;
    [SerializeField] private UnityEvent onPickUp;
    [SerializeField] private UnityEvent onDrop;

    private Inventory _inventory;
    private Rigidbody _rigidbody;

    private Animator _handAnimator;
    private int _animParameterPickup;
    
    [SerializeField] private int attackForce = 3;
    public int AttackForce => attackForce;

    [SerializeField] private string[] harvestCategories;
    public string[] HarvestCategories => harvestCategories;

    [SerializeField] private int harvestLevel;
    public int HarvestLevel => harvestLevel;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inventory = Inventory.Instance;
    }

    [ContextMenu("Rammasser")]
    public void Pickup()
    {
        if (!_inventory.TrySetItemInEmptySlot(gameObject)) return;
            onPickUp.Invoke();

        _handAnimator = _inventory.GetComponentInParent<Animator>();
        _animParameterPickup = Animator.StringToHash("Pickup");
        _handAnimator.SetTrigger(_animParameterPickup);

        Transform transform1;
        (transform1 = transform).parent = _inventory.GetComponent<Transform>();
        transform1.localPosition = pickupPosition;
        transform1.localRotation = pickupRotation;
        transform1.localScale = Vector3.one;

        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;

        foreach (var col in GetComponents<Collider>())
            col.enabled = false;
    }

    [ContextMenu("Déposer")]
    public void Drop()
    {
        _inventory.RemoveCurrentSlot();
        
        onDrop.Invoke();

        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;

        foreach (var col in GetComponents<Collider>())
            col.enabled = true;

        transform.parent = null;
        
    }
}