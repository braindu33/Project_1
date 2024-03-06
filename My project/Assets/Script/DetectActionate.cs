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
    
    /*[SerializeField] private bool openCraftInterface;
    [SerializeField] private bool openBuyInterface;*/
    //[FormerlySerializedAs("openInterface")] [SerializeField] private List<OpenInterface> openInterfaces = new();
    
    private RaycastHit hit;
    private Actionable objectLooked; 
    private Actionable actionable;
    private Actionable actionableInHand;

    private GetResourceFunction get;
    private PickableFonction pick;

    private OpenInterface openCraft, openBuy;
    private GameObject open1, open2;

    /*[SerializeField] private BuyabbleFonction buy;
    private GameObject buy1;
    [SerializeField] private CraftFonction craft;
    private GameObject craft1;*/


    /*private GameObject player;
    private OpenInterface distanceToOpen;*/
    
    private float _waitingTimeBetweenActions = 0.7f;
    
    private Animator _handAnimator; 
    private int _animParameterHit;

    private void Awake()
    {

        open1 = GameObject.FindGameObjectWithTag("Craft");
        openCraft = open1.GetComponent<OpenInterface>();

        open2 = GameObject.FindGameObjectWithTag("Shop");
        openBuy = open2.GetComponent<OpenInterface>();

        /*foreach (var openInterface in openInterfaces)
        {
            openInterface.openCraftInterface =
        }*/

        /*buy1 = GameObject.FindGameObjectWithTag("Shop");
        craft1 = GameObject.FindGameObjectWithTag("Craft");*/
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
            openCraft.OpenCraftInterface();

        if (openBuy)
            openBuy.OpenBuyInterface();

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        /*if (other.CompareTag("Player"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 5))
            {
                if (openCraftInterface)
                {
                    craft.Open();
                }
                else
                {
                    openCraftInterface = false;
                }

                if (openBuyInterface is false)
                {
                    buy.Open();
                }
                else
                {
                    openBuyInterface = true;
                }
            }
        }*/

        /*if (Physics.Raycast(ray, out hit, 5))
        {
            GameObject craftTable = GameObject.FindGameObjectWithTag("Craft");
            if (craftTable & craft)
            {
                craft.Open();
            }

            GameObject shopTable = GameObject.FindGameObjectWithTag("Shop");
            if (shopTable & buy)
            {
                buy.Open();
            }
        }*/

        /*Debug.Log("First");
        if (Physics.Raycast(ray, out hit, 5) && craft1)
        {
            Debug.Log("Second");
            craft = hit.collider.GetComponentInChildren<CraftFonction>();

            if (craft)
            {
                craft.Open();
                Debug.Log("Third");
            }
        }

        if (Physics.Raycast(ray, out hit, 10) && buy1)
        {
            Debug.Log("Deux");
            buy = hit.collider.GetComponentInChildren<BuyabbleFonction>();

            if (buy)
            {
                Debug.Log("Trois");
                buy.Open();
            }
        }*/

        /*open1 = hit.collider.GetComponent<OpenInterface>();
        if (open1)
        {
            open1.OpenCraftInterface();
        }

        open2 = hit.collider.GetComponent<OpenInterface>();
        if (open2)
        {
            open2.OpenBuyInterface();
        }*/
    }
}
