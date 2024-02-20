using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Actionable : MonoBehaviour
{
    [SerializeField] private UnityEvent firstAction;
    [SerializeField] private UnityEvent secondaryAction;

    public void FirstAction()
    {
        firstAction.Invoke();
    }

    public void SecondAction()
    {
        secondaryAction.Invoke();
    }
}
