using System.Data;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Resources/Resource Data")]
public class ResourceData : ScriptableObject
{
    [SerializeField] public string itemName;
    
    [SerializeField] public int stackMaxCount = 1;
    
    [SerializeField] public Sprite icon;
}