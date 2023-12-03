using UnityEngine;
using UnityEngine.UI;

public class InventoryContextMenu : MonoBehaviour
{
    [SerializeField] private Button dropButton, closeButton;
    
    private InventorySysteme _inventory;

    private int _targetSlotID;

    private void Awake()
    {
        dropButton.onClick.AddListener(Drop);
        closeButton.onClick.AddListener(Close);
    }

    public void Init(InventorySysteme inventory)
    {
        _inventory = inventory;
    }

    public void Select(int slotID, Slot slot)
    {
        Item slotItem = _inventory.Data[slotID];
        ItemData data = slotItem.Data;

        if (slotItem.Empty)
        {
            Close();
            return;
        }
        
        gameObject.SetActive(true);
        transform.position = slot.transform.position;

        _targetSlotID = slotID;
    }

    #region Inputs

    private void Drop()
    {
        _inventory.PickItem(_targetSlotID);
        Close(); 
    }

    private void Close()
    {
        gameObject.SetActive(false);
    }

    #endregion
}
