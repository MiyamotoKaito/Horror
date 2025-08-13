using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private KeyBase keyType;
    [SerializeField] private GameObject enemy;

    private void Start()
    {
        enemy.SetActive(false);
    }
    void Update()
    {
        if (GetKey.HasKey(keyType.keyID))//特定の鍵を持っていたらドアを開けれるようにする
        {
            enemy.SetActive(true);
        }
    }
}
