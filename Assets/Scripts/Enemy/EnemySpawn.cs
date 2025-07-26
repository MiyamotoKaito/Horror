using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] KeyBase keyType;
    [SerializeField] GameObject enemySpawner;
    void Update()
    {
        gameObject.SetActive(false);
        if (GetKey.HasKey(keyType.keyID))
        {
            Debug.Log("getkey");
            enemySpawner.SetActive(true);
        }
    }
}
