using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float speed = 10;
    [SerializeField] private float minRotation = -90;
    [SerializeField] private float maxRotation = 90;
    [SerializeField] private GameObject head;
    
    private Rigidbody _rigidbody;
    
    private Vector3 _trackNormal = Vector3.up;
    private Vector3 _newTrackNormal = Vector3.up;
    
    private Vector3 _movementX;
    private Vector3 _movementZ;
    
    private Transform _referenceTransform;
    
    private float _speedMultiplier = 200;
    private float _headTilt = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 speedVector = Vector3.zero;
        
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        if (verticalAxis != 0)
        {
            if (verticalAxis > 0)
                speedVector += _referenceTransform.forward;
            else if (verticalAxis < 0)
                speedVector -= _referenceTransform.forward;
        }
        
        if (horizontalAxis != 0)
        {
            if (horizontalAxis > 0)
                speedVector += _referenceTransform.right;
            else if (horizontalAxis < 0)
                speedVector -= _referenceTransform.right;
        }
        
        var diffNormal = _newTrackNormal - _trackNormal;
        _trackNormal += diffNormal * Time.deltaTime;
         _rigidbody.velocity -= _trackNormal * (Physics2D.gravity.magnitude * Time.deltaTime);
        
        if (speedVector != Vector3.zero)
            _rigidbody.AddForce(speedVector.normalized * (_speedMultiplier * speed * Time.deltaTime));
    }
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (Camera.main is { }) _referenceTransform = Camera.main.transform;
    }
    
    public void TiltHead (float mouseYValue)
    {
        _headTilt -= mouseYValue;
        head.transform.localRotation = Quaternion.Euler(_headTilt, 0, 0);

        if(_headTilt > maxRotation)
        {
            _headTilt = maxRotation;
        }
        if(_headTilt < minRotation)
        {
            _headTilt = minRotation;
        }

    }

    public void RotateY(float mouseXValue)
    {
        transform.Rotate(0, mouseXValue, 0);
    }

    public void SetMovementX(float horizontalValue)
    {
        _movementX = transform.right * horizontalValue;
    }

    public void SetMovementZ(float verticalValue)
    {
        _movementZ = transform.forward * verticalValue;
    }
}
