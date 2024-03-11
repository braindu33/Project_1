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
    }
}

public class NexLevel : Monobehaviour
{
    