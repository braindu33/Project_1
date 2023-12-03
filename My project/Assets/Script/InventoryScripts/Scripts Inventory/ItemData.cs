using System.Data;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] public string itemName;
    
    [SerializeField] public int stackMaxCount = 1;
    
    [SerializeField] public Sprite icon;
}