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

    private string test;
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
        /*if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3))
            {
                PickableFonction pick = hit.collider.GetComponent<PickableFonction>();

                if (pick)
                {
                    Debug.Log("Item picked");
                    onPickUp.Invoke();
                }
            }
        }*/

        if (!_inventory.TrySetItemInEmptySlot(gameObject)) return;
            onPickUp.Invoke();

        _handAnimator = _inventory.GetComponentInParent<Animator>();
        _animParameterPickup = Animator.StringToHash("Pickup");
        _handAnimator.SetTrigger(_animParameterPickup);

        transform.parent = _inventory.GetComponent<Transform>();
        transform.localPosition = pickupPosition;
        transform.localRotation = pickupRotation;
        transform.localScale = Vector3.one;

        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;

        foreach (var col in GetComponents<Collider>())
            col.enabled = false;
        
        Debug.Log("Item Picked");
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
