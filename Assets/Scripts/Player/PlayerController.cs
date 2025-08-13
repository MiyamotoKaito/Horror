using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float moveSpeed = 1.0f;
    private Rigidbody _rb;
    public float MoveSpeed {get; private set;}
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        MoveSpeed = moveSpeed;
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
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        // Y軸成分を0にして水平面での移動に制限
        cameraForward.y = 0;
        cameraRight.y = 0;

        // 正規化して一定の速度を保つ
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        // カメラの方向基準で移動ベクトルを計算（W/Sでカメラの向きに移動、A/Dで左右移動）
        Vector3 move = cameraRight * x + cameraForward * z;

        // Rigidbodyを使用して物理的な移動を実行
        _rb.velocity = move * MoveSpeed;
    }
    public void SetMoveSpeed(float speed)
    {
        MoveSpeed = speed;
    }
}