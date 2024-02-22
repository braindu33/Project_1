using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectActionate : MonoBehaviour
{
    [SerializeField] private float distance = 3;
    [SerializeField] private LayerMask layers;
    
    private RaycastHit _hit;
    private Actionable _objectLooked;
    private Actionable _actionable;
    private Actionable _actionableInHand;
    private Actionable _takeObject;
    
    private GetResourceFunction resource;
    
    private float _waitingTimeBetweenActions = 0.7f;
    
    private Animator _handAnimator;
    private int _animParameterHit;

    private void Start()
    {
        _handAnimator = Inventory.Instance.GetComponentInParent<Animator>();
        _animParameterHit = Animator.StringToHash("Hit");
    }

    private void Update()
    {
        DetectActionable();
    }

    private void DetectActionable()
    {
        _objectLooked = null;
        if(Physics.Raycast(transform.position, transform.forward, out _hit, distance, layers))
        {
            _objectLooked = _hit.transform.GetComponent<Actionable>();
        }
        
        if(_objectLooked == _actionable) return;

        if (_actionable)
        {
            _actionable.StopLooking();
        }
        _actionable = _objectLooked;

        if(_actionable)
        {
            _actionable.StartLooking();
        }
    }
    public void ActionateObjectFirstAction()
    {
        GameObject item = Inventory.Instance.GetCurrentItem();
        if (item)
        {
            _actionableInHand = item.GetComponent<Actionable>();
            if (_actionableInHand)
                _handAnimator.SetTrigger(_animParameterHit);
        }
        
        if(!_actionable) return;
        
        _actionable.FirstAction();
    }

    public void ActionateObjectSecondAction()
    {
        GameObject item = Inventory.Instance.GetCurrentItem();
        if (item)
        {
            _actionableInHand = item.GetComponent<Actionable>();
            if (_actionableInHand)
            {
                _actionableInHand.SecondAction();
                return;
            }
        }
        
        _actionableInHand = Inventory.Instance.GetComponentInChildren<Actionable>();
        if(_actionableInHand)
        {
            _actionableInHand.SecondAction();
        }

        if(_actionable) 
        {
            _actionable.SecondAction();
        }
    }

    /*public void ActionateObjectTake()
    {
        
    }*/
}
