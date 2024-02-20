using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndActionable : MonoBehaviour
{
    private Actionnable _actionable;
    private Actionnable _objectLookedAt;

    private void Update()
    {
        DetectActionable();
    }

    public void ActionateObjectMainAction()
    {
        _actionable.ActionateMainAction();
    }

    public void ActionateObjectSecondaryAction()
    {
        if(_actionable)
            _actionable.ActionateSecondaryAction();
    }

    public void DetectActionable()
    {
        _objectLookedAt = null;
        
        if(_objectLookedAt == _actionable) return;

        if(_actionable)
        {
            _actionable.StopLookingAt(); 
        }
        _actionable = _objectLookedAt;

        if(_actionable)
        {
            _actionable.StartLookingAt();
        }
    }
}
