using UnityEngine;
using Cinemachine;

public class CameraZoom : CameraController
{
    [SerializeField] CinemachineVirtualCamera FPSCamera;
    float ZoomInValue = 20;
    float ZoomOutValue = 60;
    bool isZoomed = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isZoomed)
            {
                isZoomed = true;
                FPSCamera.m_Lens.FieldOfView = ZoomInValue;
            }
            else
            {
                isZoomed = false;
                FPSCamera.m_Lens.FieldOfView = ZoomOutValue;
            }
        }
    }
}