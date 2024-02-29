using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace StudioXP.Scripts.Objects
{
    public class OutlineGroupModifier : MonoBehaviour
    {
        [SerializeField] private Outline[] outlines;

        public void Activate()
        {
            foreach (var outline in outlines)
                outline.enabled = true;
        }

        public void Deactivate()
        {
            foreach (var outline in outlines)
                outline.enabled = false;
        }
    }
}