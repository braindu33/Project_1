using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private int _index;
    private Vector3 _initialImageLocalPosition;
    
    
    [SerializeField] private TextMeshProUGUI itemCountText;
    [SerializeField] private Image itemImage;
    
    private InventoryDisplay _inventoryDisplay;

    private Button _button;

    public void Initialized(InventoryDisplay inventoryDisplay, int index)
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(OnClick);
        _index = index;
        _inventoryDisplay = inventoryDisplay;

    }

    public void UpdateDisplay(Resource item)
    {
        if (!item.Empty)
        {
            itemCountText.text = item.Count.ToString();
            itemImage.sprite = item.Data.icon;
            itemImage.color = Color.white;
            return;
        }

        itemCountText.text = "";
        itemImage.sprite = null;
        itemImage.color = new Color(0,0,0,0);
    }

    private void OnClick()
    {
        _inventoryDisplay.ClickSlot(_index);
    }
    
    #region Drag and Drop

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        _inventoryDisplay.DragSlot(_index);
        
        _initialImageLocalPosition = itemImage.transform.localPosition;
        itemImage.transform.SetParent(_inventoryDisplay.transform);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        itemImage.transform.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        itemImage.transform.SetParent(transform);
        itemImage.transform.localPosition = _initialImageLocalPosition;
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        
        _inventoryDisplay.DropOnSlot(_index);
    }
    #endregion
}
