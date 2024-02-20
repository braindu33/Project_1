using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] private GameObject head;
    [SerializeField] private float minSpeed = 4;
    [SerializeField] private float maxSpeed = 6;
    [SerializeField] private float minRotation = -90;
    [SerializeField] private float maxRotation = 90;

    private float _headTilt = 0;
    private float _speed;

    private CharacterController _characterController;

    private Vector3 _movementX;
    private Vector3 _movementZ;

    

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _speed = minSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = (_movementX + _movementZ).normalized;

        _characterController.Move(Physics.gravity * Time.deltaTime);
        _characterController.Move(movement * Time.deltaTime * _speed);
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

    public void ApplyMinSpeed()
    { 
        _speed = minSpeed;
    }

    public void ApplyMaxSpeed()
    {
        _speed = maxSpeed;
    }
}
