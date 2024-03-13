using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class DetectActionate : MonoBehaviour
{
    [SerializeField] private float distance = 3;
    [SerializeField] private LayerMask layers;
    
    [SerializeField] private CraftFonction craft;
    [SerializeField] private BuyabbleFonction buy;
    //[FormerlySerializedAs("getXpFunction")] [SerializeField] private List<GetXpFunction> getXpFunctions = new();
    
    private RaycastHit hit;
    private Actionable objectLooked; 
    private Actionable actionable;
    private Actionable actionableInHand;
    
    private GetResourceFunction get;
    private PickableFonction pick;

    private OpenCraftInterface openCraft;
    private OpenBuyInterface openBuy;
    private GameObject open1, open2;
    
    private float _waitingTimeBetweenActions = 0.7f;
    
    private Animator _handAnimator; 
    private int _animParameterHit;

    private void Awake()
    {
        /*foreach (var getXpFunction in getXpFunctions)
        {
            getXpFunction.get = ActionateObjectTake;
        }*/

        open1 = GameObject.FindGameObjectWithTag("Craft");
        openCraft = open1.GetComponent<OpenCraftInterface>();

        open2 = GameObject.FindGameObjectWithTag("Shop");
        openBuy = open2.GetComponent<OpenBuyInterface>();
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

    public void ActionateInteractedObject()
    {
        if(openCraft)
            openCraft.OpenInterfaceCraft();

        if (openBuy)
            openBuy.OpenInterfaceBuy();
    }

    public void Escape()
    {
        buy.Close();
        craft.Close();
    }
}
