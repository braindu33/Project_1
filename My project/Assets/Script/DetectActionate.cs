using UnityEngine;

public class DetectActionate : MonoBehaviour
{
    [SerializeField] private float distance = 3;
    //[SerializeField] private LayerMask layers;
    
    [SerializeField] private CraftFonction craft;
    [SerializeField] private BuyabbleFonction buy;
    private HarvestableFunction harvest;
    private RaycastHit hit;
    
    private Actionable objectLooked; 
    private Actionable actionable;
    private Actionable actionableInHand;
    
    private GetResourceFunction get;
    private PickableFonction pick;

    private NexLevel nexLevel;
    private OpenCraftInterface openCraft;
    private OpenBuyInterface openBuy;
    private GameObject open1, open2;
    
    //private float _waitingTimeBetweenActions = 0.7f;
    
    /*private Animator _handAnimator; 
    private int _animParameterHit;*/

    /*private void Awake()
    {
        open1 = GameObject.FindGameObjectWithTag("Craft");
        openCraft = open1.GetComponent<OpenCraftInterface>();

        open2 = GameObject.FindGameObjectWithTag("Shop");
        openBuy = open2.GetComponent<OpenBuyInterface>();
    }*/

    private void Start()
    {
        /*_handAnimator = Inventory.Instance.GetComponentInParent<Animator>();
        _animParameterHit = Animator.StringToHash("Hit");*/
    }

    private void Update()
    {
        DetectActionable();
    }

    private void DetectActionable()
    {
        /*objectLooked = null;
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
        }*/
    }
    public void ActionateObjectFirstAction()
    {
        if (Camera.main != null)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var itemInHand = Inventory.Instance.GetCurrentItem();
            if (!itemInHand) return;
        
            if(!Physics.Raycast(ray, out hit, distance)) return;
        }

        harvest = hit.collider.GetComponent<HarvestableFunction>();
        if (harvest) 
            harvest.Harvest();
    }

    public void ActionateObjectSecondAction()
    {
        var item = Inventory.Instance.GetCurrentItem();
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
        if (Camera.main != null)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            if (!Physics.Raycast(ray, out hit, distance)) return;
        
            get = hit.collider.GetComponent<GetResourceFunction>();

            if (get)
                get.GetResource();

            if (!Physics.Raycast(ray, out hit, distance)) return;
        }

        pick = hit.collider.GetComponent<PickableFonction>();   
        if(pick)
            pick.Pickup();
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
