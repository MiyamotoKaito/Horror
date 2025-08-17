using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKey : MonoBehaviour
{
    [SerializeField] private Vector3 axis = Vector3.up;//âÒì]é≤
    [SerializeField] private GameObject uiKey;//íÜêSì_
    [SerializeField] private float rotationSpeed;
    private void FixedUpdate()
    {
        transform.RotateAround(uiKey.transform.position, axis, rotationSpeed * Time.deltaTime);
    }
}
