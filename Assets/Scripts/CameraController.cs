using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Cinemachine;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;
    Vector2 moveInput = Vector2.zero;
    [SerializeField] float moveSpeed = 2.5f;
    [SerializeField] float rotationSpeed = 50f;
    Vector3 rotation;
    float rotationAngle;
    float zoomInput = 0.5f;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    float targetFOV;
    [SerializeField] float minPOV = 35f;
    [SerializeField] float maxPOV = 90f;
    [SerializeField] float zoomSensitivity = 15f;
    
    public void OnInputCameraMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnInputRotateCamera(InputAction.CallbackContext context)
    {
        rotationAngle = context.ReadValue<float>();
    }

    public void OnInputZoomCamera(InputAction.CallbackContext context)
    {
        zoomInput = context.ReadValue<float>();
    }

    private void Start()
    {
        //targetFOV = virtualCamera.m_Lens.FieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
        RotateCamera();
        Zoom();
    }

    private void Zoom()
    {
        targetFOV += zoomInput * zoomSensitivity;
        targetFOV = Mathf.Clamp(targetFOV, minPOV, maxPOV);
        virtualCamera.m_Lens.FieldOfView = targetFOV;
    }

    private void RotateCamera()
    {
        rotation.y = rotationAngle * rotationSpeed * Time.deltaTime;
        transform.eulerAngles += rotation;
    }

    private void CameraMove()
    {
        moveVector = transform.right * moveInput.x + transform.forward * moveInput.y;

        transform.position += moveVector * Time.deltaTime * moveSpeed;
    }
}
