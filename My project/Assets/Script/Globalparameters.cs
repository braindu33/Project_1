using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globalparameters : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;     
    }
}

public class Levels
{
    [SerializeField] public Button nexLevelButton;

    public void LevelUp()
    {
        gameObject.SetActive(true);
        Debug.Log("Level unlocked ");
    }
}

public class NexLevel : Monobehaviour
{
    [FormerlySerializedAs("level")] [SerializeField] private List<Levels> levels = new();

    private void Awake()
    {
        foreach( var level in levels)
        {
            level.nexLevelButton.onClick.AddListener(level.LevelUp);
    }
}