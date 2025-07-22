using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public Transform cameraTransform;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        // Y��������0�ɂ��Đ����ʂł̈ړ��ɐ���
        cameraForward.y = 0;
        cameraRight.y = 0;

        // ���K�����Ĉ��̑��x��ۂ�
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        // �J�����̕�����ňړ��x�N�g�����v�Z�iW/S�ŃJ�����̌����Ɉړ��AA/D�ō��E�ړ��j
        Vector3 move = cameraRight * x + cameraForward * z;

        // Rigidbody���g�p���ĕ����I�Ȉړ������s
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
}