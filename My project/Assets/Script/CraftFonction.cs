using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CraftFonction : MonoBehaviour
{
    [FormerlySerializedAs("itemCraft")] public List<ItemCraft> itemCrafts = new ();

    //private Vector3 positionSpawn;

    private void Awake()
    {
        foreach (var itemCraft in itemCrafts)
        { 
            itemCraft.close = Close;
            itemCraft.craftButton.onClick.AddListener(itemCraft.Craft);
        }
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    private void Close()
    {
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
