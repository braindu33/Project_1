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
    }

    [ContextMenu("Rammasser")]
    public void Pickup()
    {
        if (Input.GetMouseButtonDown(1))
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
        }

        _animParameterPickup = Animator.StringToHash("Pickup");
        _handAnimator.SetTrigger(_animParameterPickup);

        transform.localPosition = pickupPosition;
        transform.localRotation = pickupRotation;
        transform.localScale = Vector3.one;

        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;

        foreach (var col in GetComponents<Collider>())
            col.enabled = false;
    }

    [ContextMenu("Déposer")]
    public void Drop()
    {
        onDrop.Invoke();

        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;

        foreach (var col in GetComponents<Collider>())
            col.enabled = true;
    }
}
