using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class XpUIController : MonoBehaviour
{
    public static XpUIController Instance { get; private set;}
    
    [SerializeField] private List<TextMeshProUGUI> textXp;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void UpdateXpUI(int index, int value)
    {
        textXp[index].text = value + "XP";
        Debug.Log("Xp is update");
    }
}