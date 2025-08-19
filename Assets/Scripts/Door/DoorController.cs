using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] KeyBase keyType;
    private AudioSource _myAudioSource;
    private Animator _doorAnimator;
    private bool _isCollect = false;
    private bool _doorOpen = false;
    private bool _nearByDoor = false;
    private void Start()
    {
        _myAudioSource = GetComponent<AudioSource>();
        _doorAnimator = GetComponent<Animator>();
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_nearByDoor && _isCollect == true)
            {
                if (_doorOpen == false)
                {
                    AudioManager.Instance.PlaySE("開ける", _myAudioSource);
                    Debug.Log("ドアを開けようとしている!!");
                    _doorAnimator.SetBool("IsOpen", true);
                    _doorAnimator.SetBool("IsClose", false);
                    _doorOpen = true;
                }
                else if (_doorOpen == true)
                {
                    AudioManager.Instance.PlaySE("閉める", _myAudioSource);
                    Debug.Log("ドアを閉めようとしている!!");
                    _doorAnimator.SetBool("IsClose", true);
                    _doorAnimator.SetBool("IsOpen", false);
                    _doorOpen = false;
                }
            }
            else if(_nearByDoor && _isCollect == false)
            {
                AudioManager.Instance.PlaySE("開かない", _myAudioSource);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _nearByDoor = true;
            Debug.Log("ドアにぶつかった！！");
            if (GetKey.HasKey(keyType.keyID))//特定の鍵を持っていたらドアを開けれるようにする
            {
                Debug.Log("鍵がありましたわーい");
                _isCollect = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _nearByDoor = false;
        if (other.CompareTag("Player"))
        {
            Debug.Log("ドアから離れた！！");
            _isCollect = false;
        }
    }
}
