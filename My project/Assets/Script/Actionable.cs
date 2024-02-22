using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Actionable : MonoBehaviour
{
    [SerializeField] private UnityEvent firstAction;
    [SerializeField] private UnityEvent secondaryAction;
    [SerializeField] private UnityEvent startLooking;
    [SerializeField] private UnityEvent stopLooking;
    [SerializeField] private UnityEvent takeAction;
    public void FirstAction()
    {
        firstAction.Invoke();
    }

    public void SecondAction()
    {
        secondaryAction.Invoke();
    }

    public void StartLooking()
    {
        startLooking.Invoke();
    }

    public void StopLooking()
    {
        stopLooking.Invoke();
    }

    public void TakeAction()
    {
        takeAction.Invoke();
    }
}
