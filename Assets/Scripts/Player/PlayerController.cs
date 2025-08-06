using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _moveSpeed = 1.0f;
    private Transform _cameraTransform;
    private Rigidbody _rb;
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

        // �J�����̕�������ɂ����ړ��x�N�g�����v�Z
        Vector3 cameraForward = _cameraTransform.forward;
        Vector3 cameraRight = _cameraTransform.right;

        // Y��������0�ɂ��Đ����ʂł̈ړ��ɐ���
        cameraForward.y = 0;
        cameraRight.y = 0;

        // ���K�����Ĉ��̑��x��ۂ�
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        // �J�����̕�����ňړ��x�N�g�����v�Z�iW/S�ŃJ�����̌����Ɉړ��AA/D�ō��E�ړ��j
        Vector3 move = cameraRight * x + cameraForward * z;

        // Rigidbody���g�p���ĕ����I�Ȉړ������s
        _rb.velocity = move * _moveSpeed;
    }
}