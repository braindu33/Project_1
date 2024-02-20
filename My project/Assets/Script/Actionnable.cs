using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Actionnable : MonoBehaviour
{
    [SerializeField] private UnityEvent onMainAction;
    [SerializeField] private UnityEvent onSecondaryAction;
    [SerializeField] private UnityEvent onStartLookingAt;
    [SerializeField] private UnityEvent onStopLookingAt;

    public void ActionateMainAction()
    {
        onMainAction.Invoke();
    }

    public void ActionateSecondaryAction()
    {
        onSecondaryAction.Invoke();
    }

    public void StartLookingAt()
    {
        onStartLookingAt.Invoke();
    }

    public void StopLookingAt()
    {
        onStopLookingAt.Invoke();
    }
}
