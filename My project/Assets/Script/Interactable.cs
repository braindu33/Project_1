using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
    [FormerlySerializedAs("onStartLookAt")] [SerializeField] private UnityEvent startedLookingAt;
    [FormerlySerializedAs("onStopLookAt")] [SerializeField] private UnityEvent stoppedLookingAt;
        
    public void StartLookingAt()
    {
        startedLookingAt.Invoke();
    }

    public void StopLookingAt()
    {
        stoppedLookingAt.Invoke();
    }
}