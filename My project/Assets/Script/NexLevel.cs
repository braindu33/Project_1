using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NexLevel : MonoBehaviour
{
    [FormerlySerializedAs("level")] [SerializeField] private List<Levels> levels = new();

    private void Awake()
    {
        foreach (var level in levels)
        {
            level.nexLevelButton.onClick.AddListener(level.LevelUp);
            level.close = Close;
        }
    }
    
    public void OpenLevelUpInterface()
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