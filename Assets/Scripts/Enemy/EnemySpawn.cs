using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] KeyBase keyType;
    [SerializeField] GameObject enemy;
    private bool hasActivated = false; // 一度だけ実行するためのフラグ

    void Update()
    {
        if (GetKey.HasKey(keyType.keyID))//特定の鍵を持っていたらドアを開けれるようにする
        {
            Instantiate(enemy);
        }
    }
}
