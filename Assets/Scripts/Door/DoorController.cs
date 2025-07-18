using System.Runtime.CompilerServices;
using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator _doorAnimator;
    private bool _doorOpen = false;
    private bool _inTriger = false;
    private void Start()
    {
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
                Debug.Log("ドアを開けようとしている!!");
                _doorAnimator.SetBool("IsOpen", true);
                _doorAnimator.SetBool("IsClose", false);
                _doorOpen = true;
            }
            else if (_doorOpen == true)
            {
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
            if (GetKey._getKey == true)
                _inTriger = true;
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
