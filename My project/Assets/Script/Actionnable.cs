using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Actionnable : MonoBehaviour
{
    [SerializeField] private UnityEvent onMainAction;
    [SerializeField] private UnityEvent onSecondaryAction;

    public void ActionateMainAction()
    {
        onMainAction.Invoke();
    }

    public void ActionateSecondaryAction()
    {
        onSecondaryAction.Invoke();
    }
}
