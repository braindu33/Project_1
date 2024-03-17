using System;
using System.Collections;
using UnityEngine;

public class Globalparameters : MonoBehaviour
{
    [SerializeField] private NexLevel nexLevel;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;     
    }

    private void Update()
    {
        nexLevel.OpenLevelUpInterface();
    }
}