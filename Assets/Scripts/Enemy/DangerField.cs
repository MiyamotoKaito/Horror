using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DangerField : MonoBehaviour
{
    [SerializeField] private Image fov;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private GameObject parent;
    private float _playerDefaultSpeed;
    private bool isActive;

    private Coroutine _dangerCoroutine;
    void Start()
    {
        fov.color = Color.clear;
        _playerDefaultSpeed = playerController.MoveSpeed;
    }
    void Update()
    {
        fov.color = Color.Lerp(fov.color, Color.clear, Time.deltaTime);
    }

    void OnDisable()
    {
        if (isActive)
        {
            ExitArea();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = true;
            playerController.SetMoveSpeed(playerController.SlowSpeed);
            AudioManager.Instance.PlayBGM("心臓音", bgmAudioSource);
            _dangerCoroutine = StartCoroutine(Danger());
        }
        if (other.CompareTag("Destination"))
        {
            Debug.Log("幽霊が消えた");
            parent.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ExitArea();
        }
    }
    private IEnumerator Danger()
    {
        fov.color = Color.black;
        yield return null;
    }

    private void ExitArea()
    {
        if (_dangerCoroutine != null)
        {
            playerController.SetMoveSpeed(_playerDefaultSpeed);
            AudioManager.Instance.StopAudio(bgmAudioSource);
            StopCoroutine(_dangerCoroutine);
            _dangerCoroutine = null;
        }
    }
}