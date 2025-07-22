using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] KeyBase keyType;
    public Animator doorAnimator;
    private bool _doorOpen = false;
    private bool _inTriger = false;
    private void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        DoorAnimation();
    }
    /// <summary>
    /// ドアの開け閉めのアニメーションを遷移させる用のメソッド
    /// </summary>
    private void DoorAnimation()
    {
        if (Input.GetKeyDown(KeyCode.F) && _inTriger == true)
        {
            if (_doorOpen == false)
            {
                Debug.Log("ドアを開けようとしている!!");
                doorAnimator.SetBool("IsOpen", true);
                doorAnimator.SetBool("IsClose", false);
                _doorOpen = true;
            }
            else if (_doorOpen == true)
            {
                Debug.Log("ドアを閉めようとしている!!");
                doorAnimator.SetBool("IsClose", true);
                doorAnimator.SetBool("IsOpen", false);
                _doorOpen = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ドアにぶつかった！！");
            if (GetKey.HasKey(keyType.keyID))//特定の鍵を持っていたらドアを開けれるようにする
            {
                _inTriger = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ドアから離れた！！");
            _inTriger = false;
        }
    }
}
