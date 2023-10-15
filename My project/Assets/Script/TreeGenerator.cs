using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject treeObject;
    public GameObject treesInWorldObject;

    public int treeAmount;

    List<GameObject> treesList = new List<GameObject>();

    GameObject[] treesArray;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= treeAmount; i++)
        {
            treesList.Add(Instantiate<GameObject>(treeObject));
            treesArray = treesList.ToArray();
            treesArray[i].transform.position = new Vector3(Random.Range(-42, 42), 0, Random.Range(-42, 42));
            treesArray[i].transform.parent = treesInWorldObject.transform;
        }
    }
}
