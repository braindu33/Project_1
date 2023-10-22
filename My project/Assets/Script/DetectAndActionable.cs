using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndActionable : MonoBehaviour
{
    private Actionnable _actionable;

    public void ActionateObjectMainAction()
    {
        _actionable.ActionateMainAction();
    }

    private void ActionateObjectSecondaryAction()
    {
        if(_actionable)
            _actionable.ActionateSecondaryAction();
    }
}
