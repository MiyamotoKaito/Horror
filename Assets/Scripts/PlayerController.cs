using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 1.0f;
    public Transform _cameraTransform;
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // カメラの方向を基準にした移動ベクトルを計算
        Vector3 cameraForward = _cameraTransform.forward;
        Vector3 cameraRight = _cameraTransform.right;

        // Y軸成分を0にして水平面での移動に制限
        cameraForward.y = 0;
        cameraRight.y = 0;

        // 正規化して一定の速度を保つ
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        // カメラの方向基準で移動ベクトルを計算（W/Sでカメラの向きに移動、A/Dで左右移動）
        Vector3 move = cameraRight * x + cameraForward * z;

        // Rigidbodyを使用して物理的な移動を実行
        _rb.MovePosition(_rb.position + move * _speed * Time.fixedDeltaTime);
    }
}