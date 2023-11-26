using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private int _index;

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

    public void UpdateDisplay(Item item)
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
        print("Begin : " + _index);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        print("Drag : " + _index);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        print("End : " + _index);
    }
    
    #endregion
}
