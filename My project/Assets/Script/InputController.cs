using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputEvent[] inputs;

    private void Update()
    {
        foreach (var input in inputs)
            input.Update();
    }
}
