using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ResourceUIController : MonoBehaviour
{
    public static ResourceUIController Instance { get; private set;}
    
    [SerializeField] private List<TextMeshProUGUI> textResources;
    [SerializeField] private List<TextMeshProUGUI> xpText;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void UpdateResourceUI(int index, int value)
    {
        textResources[index].text = value.ToString();
    }

    public void UpdateXpUI(int index, int value)
    {
        xpText[index].text = value.ToString();
    }
}