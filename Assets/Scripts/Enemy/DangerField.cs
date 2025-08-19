using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DangerField : EnemyBase
{
    [SerializeField] private Image fov;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private AudioSource bgmAudioSource;
    private float _playerDefaultSpeed;

    private Coroutine _dangerCoroutine;
    protected override void Start()
    {
        fov.color = Color.clear;
        _playerDefaultSpeed = playerController.MoveSpeed;
    }
    void Update()
    {
        fov.color = Color.Lerp(fov.color, Color.clear, Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //アニメーション
            playerController.SetMoveSpeed(playerController.SlowSpeed);

            _dangerCoroutine = StartCoroutine(Danger());
        }
        if (other.CompareTag("Destination"))
        {
            Debug.Log("幽霊が消えた");
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //アニメーション
            playerController.SetMoveSpeed(_playerDefaultSpeed);

            AudioManager.Instance.StopAudio(bgmAudioSource);
            StopCoroutine(_dangerCoroutine);
            _dangerCoroutine = null;
        }
    }
    private IEnumerator Danger()
    {
        AudioManager.Instance.PlayBGM("心臓音", bgmAudioSource);
        //抜け出すまでループさせる
        while (true) 
        {
            fov.color = Color.black;
            yield return null;
        }
    }
}