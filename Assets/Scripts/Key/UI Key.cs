using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKey : MonoBehaviour
{
    [SerializeField] private Vector3 axis = Vector3.up;//回転軸
    [SerializeField] private GameObject uiKey;//中心点
    [SerializeField] private float rotationSpeed;
    private void FixedUpdate()
    {
        transform.RotateAround(uiKey.transform.position, axis, rotationSpeed * Time.deltaTime);
    }
}
