using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKey : MonoBehaviour
{
    [SerializeField] private Vector3 axis = Vector3.up;//��]��
    [SerializeField] private GameObject uiKey;//���S�_
    [SerializeField] private float rotationSpeed;
    private void FixedUpdate()
    {
        transform.RotateAround(gameObject.transform.position, axis, rotationSpeed * Time.deltaTime);
    }
}
