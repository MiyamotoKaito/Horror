using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] KeyBase keyType;
    private AudioSource _myAudioSource;
    private Animator doorAnimator;
    private bool _inTriger = false;
    private bool _doorOpen = false;
    private void Start()
    {
        _myAudioSource = GetComponent<AudioSource>();
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
            AudioManager.Instance.PlaySE("ドアの開け閉め",_myAudioSource);
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
                Debug.Log("鍵がありましたわーい");
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
