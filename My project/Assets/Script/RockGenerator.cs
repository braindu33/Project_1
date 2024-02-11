using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    public GameObject rockObject;
    //public GameObject treesInWorldObject;

    public int rockAmount;

    List<GameObject> rockList = new List<GameObject>();

    GameObject[] rocksArray;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= rockAmount; i++)
        {
            rockList.Add(Instantiate<GameObject>(rockObject));
            rocksArray = rockList.ToArray();
            rocksArray[i].transform.position = new Vector3(Random.Range(-42, 42), 0, Random.Range(-42, 42));
            //treesArray[i].transform.parent = treesInWorldObject.transform;
        }
    }
}
