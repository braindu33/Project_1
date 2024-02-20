using UnityEngine;
using UnityEngine.Events;

public class OpenInterface : MonoBehaviour
{
    [SerializeField] private UnityEvent openInterface;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3))
            {
                OpenInterface open = hit.collider.GetComponent<OpenInterface>();
                
                if(open)
                    openInterface.Invoke();
            }
        }
    }
}
