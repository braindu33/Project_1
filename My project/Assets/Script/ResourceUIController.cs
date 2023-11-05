using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceUIController : MonoBehaviour
{
    public static ResourceUIController Instance { get; private set;}
    
    [SerializeField] private List<TextMeshProUGUI> textResources;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void UpdateResourceUI(int index, int value)
    {
        textResources[index].text = value.ToString();
    }
}
