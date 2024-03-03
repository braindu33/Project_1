using System;
using UnityEngine;
using UnityEngine.Events;

public class OpenInterface : MonoBehaviour
{
    [SerializeField] private int maxDistance;

    //private Vector3 playerPos;

    [SerializeField] private OpenInterface open;
    [SerializeField] private CraftFonction craft;
    private RaycastHit hit;

    /*private void Awake()
    {
        playerPos = playerTreansform.position;
    }*/

    public void OnTriggerEnter(Collider other)
    {
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if(maxDistance >= )
        }*/
        Debug.Log("First");
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Second");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                open = hit.collider.GetComponent<OpenInterface>();

                if (open)
                {
                    Debug.Log("Third");
                    craft.Open();
                }
            }
        }
    }
}
