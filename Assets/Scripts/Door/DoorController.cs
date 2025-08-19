using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] KeyBase keyType;
    private AudioSource _myAudioSource;
    private Animator _doorAnimator;
    private bool _inTriger = false;
    private bool _doorOpen = false;
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
        if (Input.GetKeyDown(KeyCode.F) && _inTriger == true)
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
