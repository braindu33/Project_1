using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class OpenAndClose : MonoBehaviour
{
    [SerializeField] private int openDistance;
    
    private Animator openDoor;
    private RaycastHit hit;
    
    private static readonly int DoorOpen = Animator.StringToHash("OpenDoor");

    private void Awake()
    {
        openDoor = GetComponent<Animator>();
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.O))
            openDoor.SetBool(DoorOpen, true);*/
        if(Input.GetKeyDown(KeyCode.C))
            openDoor.SetBool(DoorOpen, false);
    }

    public void OpenDoor()
    {
        /*if(Camera.main == null) return; 
        Debug.Log("1");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit, openDistance)) return;
        Debug.Log("2");
        var open = hit.collider.GetComponent<OpenAndClose>();
        if (!open) return;*/
        
        
        openDoor.SetBool(DoorOpen, true);
        var col = GetComponent<Collider>();
        col.enabled = false;
        
        Debug.Log("3");
    }

    public void Close()
    {
        if(Camera.main == null) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit, openDistance)) return;

        var close = hit.collider.GetComponent<OpenAndClose>();
        
    }
}