using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftFonction : MonoBehaviour
{
    public List<ItemCraft> itemCraft = new ();
    
    private int woodIndex, rockIndex;
    private int woodCount = 1;
    private int brickCount = 3;

    private Vector3 positionSpawn;

    private Button craftButton;
    
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        craftButton.onClick.AddListener(Craft);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    #region Input

    private void Craft()
    {
        if (Inventory.Instance.RemoveResource(woodIndex & rockIndex, woodCount & brickCount))
        {
            _spawner.Spawn(positionSpawn);
        }
        Close();
    }

    private void Close()
    {
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    #endregion
}
