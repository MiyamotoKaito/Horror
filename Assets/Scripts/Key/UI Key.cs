using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKey : MonoBehaviour
{
    [SerializeField] private float rotateY;    
    private void FixedUpdate()
    {
        this.gameObject.transform.Rotate(new Vector3(0, rotateY, 0) * Time.deltaTime);
    }
}
