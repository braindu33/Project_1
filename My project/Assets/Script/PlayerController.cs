using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InputsEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent buttonDown;
    [SerializeField] private UnityEvent buttonUp;
    
        [System.Serializable]
        public class MouseeInputs
        {
            [SerializeField] private UnityEvent buttonDown;
            [SerializeField] private UnityEvent buttonUp;
        }
}
