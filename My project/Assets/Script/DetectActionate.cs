using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DetectActionate : MonoBehaviour
{
    [SerializeField] private float distance = 3;
    [SerializeField] private LayerMask layers;
    //[SerializeField] private string typeTag;
    
    private RaycastHit hit;
    private Actionable objectLooked; 
    private Actionable actionable;
    private Actionable actionableInHand;

    private GetResourceFunction get;
    private PickableFonction pick;

    private float _waitingTimeBetweenActions = 0.7f;
    
    private Animator _handAnimator;
    private int _animParameterHit;

    private void Awake()
    {
        
    }

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
        objectLooked = null;
        if(Physics.Raycast(transform.position, transform.forward, out hit, distance, layers))
        {
            objectLooked = hit.transform.GetComponent<Actionable>();
        }
        
        if(objectLooked == actionable) return;

        if (actionable)
        {
            actionable.StopLooking();
        }
        actionable = objectLooked;

        if(actionable)
        {
            actionable.StartLooking();
        }
    }
    public void ActionateObjectFirstAction()
    {
        GameObject item = Inventory.Instance.GetCurrentItem();
        if (item)
        {
            actionableInHand = item.GetComponent<Actionable>();
            if (actionableInHand)
                _handAnimator.SetTrigger(_animParameterHit);
        }
        
        if(!actionable) return;
        
        actionable.FirstAction();
    }

    public void ActionateObjectSecondAction()
    {
        GameObject item = Inventory.Instance.GetCurrentItem();
        if (item)
        {
            actionableInHand = item.GetComponent<Actionable>();
            if (actionableInHand)
            {
                actionableInHand.SecondAction();
                return;
            }
        }
        
        actionableInHand = Inventory.Instance.GetComponentInChildren<Actionable>();
        if(actionableInHand)
        {
            actionableInHand.SecondAction();
        }

        if(actionable) 
        {
            actionable.SecondAction();
        }
    }

    public void ActionateObjectTake()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3))
        { 
            get = hit.collider.GetComponent<GetResourceFunction>();

            if (get)
            {
                get.GetResource();
            }
        }

        if (Physics.Raycast(ray, out hit, 5))
        {
            pick = hit.collider.GetComponent<PickableFonction>();
            if(pick)
                pick.Pickup();
        }
    }
}
