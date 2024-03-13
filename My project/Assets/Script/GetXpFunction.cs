using System;
using UnityEngine;

public class GetXpFunction : MonoBehaviour
{
    [SerializeField] public int xpValue = 5;
    [SerializeField] public int index = 2;

    //public Action get;

    
    public void GetXp()
    {
        //get.Invoke();
        Inventory.Instance.GetXp(index).AddXp(xpValue);
        Destroy(gameObject);
    }
}