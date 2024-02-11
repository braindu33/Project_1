using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int quantity = 3;
    [SerializeField] private GameObject prefab;

    //[SerializeField] private float bonusPercentage = 10.0f;
    //[SerializeField] private int bonusQuantity = 2;


    //private void Awake()
    //{
        //float rdm = Random.Range(0,100);
        //if(rdm <= bonusPercentage)
        //{
            //quantity += bonusQuantity;
        //}

    //}

    public void Spawn(Vector3 position)
    {
        for(int i = 0; i < quantity; i++)
        {
            Instantiate(prefab, null).transform.position = position;
        }
    }
}
