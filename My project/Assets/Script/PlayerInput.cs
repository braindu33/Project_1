using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputEvent[] inputs;
    
    void Update()
    {
        foreach (var input in inputs)
            input.Update();
    }
}
