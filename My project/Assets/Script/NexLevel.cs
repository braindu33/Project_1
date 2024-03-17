using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NexLevel : MonoBehaviour
{
    [FormerlySerializedAs("level")] [SerializeField] private List<Levels> levels = new();

    [SerializeField] private int xpIndex;
    private void Awake()
    {
        foreach (var level in levels)
        {
            level.nexLevelButton.onClick.AddListener(level.LevelUp);
            level.close = Close;
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OpenLevelUpInterface()
    {
        if (!Inventory.Instance.GetXpCount(xpIndex)) return;
        
        gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Interface is Open");
    }

    private void Close()
    {
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}