using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopFunction : MonoBehaviour
{
    [SerializeField] private int itemValue;
    [SerializeField] private TextMeshPro textComponent;
    
    private ResourceSpawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<ResourceSpawner>();
        BuyObject();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3))
            {
                gameObject.SetActive(true);
            }
        }
        
        Debug.Log("The lidt is open");
    }

    private void BuyObject()
    {
        if (Resource.Instance.RemoveResource(itemValue))
        {
            _spawner.Spawn();
        }
        
        Debug.Log("Item is pick");
    }

    private void Start()
    {
        textComponent.text = itemValue + "Wood";
    }
}