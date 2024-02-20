using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectActionate : MonoBehaviour
{
    [SerializeField] private float distance = 3;
    
    private RaycastHit _hit;
    private Actionable _actionable;
    private Actionable _actionableInHand;
    
    private float _waitingTimeBetweenActions = 0.7f;
    
    private Animator _handAnimator;
    private int _animParameterHit;

    private void Start()
    {
        _handAnimator = Inventory.Instance.GetComponentInParent<Animator>();
        _animParameterHit = Animator.StringToHash("Hit");
    }

    public void ActionateObjectFirstAction()
    {
        if(!_actionable) return;
        
        _actionable.FirstAction();
    }

    public void ActionateObjectSecondAction()
    {
        _actionableInHand = InventorySystem.Instance.GetComponentInChildren<Actionable>();
        if(_actionableInHand)
        {
            _actionableInHand.SecondAction();
        }

        if(_actionable) 
        {
            _actionable.SecondAction();
        }
    }
}
