using UnityEngine;

public class DetectActionate : MonoBehaviour
{
    [SerializeField] private float distance = 3;
    //[SerializeField] private LayerMask layers;
    
    [SerializeField] private CraftFonction craft;
    [SerializeField] private BuyabbleFonction buy;
    [SerializeField] private HarvestableFunction harvestTree, harvestRock;

    private OpenAndClose openAndClose;
    private RaycastHit hit;
    
    private GetResourceFunction get;
    private PickableFonction pick;

    private NexLevel nexLevel;
    private OpenCraftInterface openCraft;
    private OpenBuyInterface openBuy;
    private GameObject open1, open2;

    private GameObject rock;
    private GameObject tree;

    private Animator harvestRockAnimation;
    private static readonly int ShakeStep1 = Animator.StringToHash("First Shake");
    private static readonly int ShakeStep2 = Animator.StringToHash("Second Shake");
    private static readonly int ShakeStep3 = Animator.StringToHash("Third Shake");
    private static readonly int ShakeFinalStep = Animator.StringToHash("Final Shake");

    private int clickCount = 0;
    
    //private float _waitingTimeBetweenActions = 0.7f;
    
    /*private Animator _handAnimator; 
    private int _animParameterHit;*/

    private void Awake()
    {
        /*open1 = GameObject.FindGameObjectWithTag("Craft");
        openCraft = open1.GetComponent<OpenCraftInterface>();

        open2 = GameObject.FindGameObjectWithTag("Shop");
        openBuy = open2.GetComponent<OpenBuyInterface>();*/

        tree = GameObject.FindGameObjectWithTag("tree");
        harvestTree = tree.GetComponent<HarvestableFunction>();
        
        rock = GameObject.FindGameObjectWithTag("rock");
        harvestRock = rock.GetComponent<HarvestableFunction>();
    }

    private void Start()
    {
        /*_handAnimator = Inventory.Instance.GetComponentInParent<Animator>();
        _animParameterHit = Animator.StringToHash("Hit");*/
    }

    private void Update()
    {
        //DetectActionable();
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
        clickCount++;
        if (Camera.main != null)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var itemInHand = Inventory.Instance.GetCurrentItem();
            if (!itemInHand) return;
        
            if(!Physics.Raycast(ray, out hit, distance)) return;
        }

        harvestTree = hit.collider.GetComponent<HarvestableFunction>();
        if (harvestTree) 
            harvestTree.HarvestTree();
        

        harvestRock = hit.collider.GetComponent<HarvestableFunction>();
        if(harvestRock) return;
        switch (clickCount)
        {
            case 1:
                harvestRockAnimation.SetTrigger(ShakeStep1);
                break;
            case 2:
                harvestRockAnimation.SetTrigger(ShakeStep2);
                break;
            case 3:
                harvestRockAnimation.SetTrigger(ShakeStep3);
                break;
            case 4:
                harvestRockAnimation.SetTrigger(ShakeFinalStep);
                break;
        }
        //harvestRock.HarvestRock();
        
    }

    public void ActionateObjectSecondAction()
    {
        /*var item = Inventory.Instance.GetCurrentItem();
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
        }*/
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
        
        /*if(Camera.main == null) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit, 5)) return;

        openAndClose = hit.collider.GetComponent<OpenAndClose>();
        if(openAndClose)
            openAndClose.OpenDoor();
        
        /*if(door)
            door.OpenDoor();*/
    }

    public void Escape()
    {
        buy.Close();
        craft.Close();
    }
}