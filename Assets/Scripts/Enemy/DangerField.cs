using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DangerField : EnemyBase
{
    [SerializeField] Image fov;
    [SerializeField] private PlayerController playerController;
    private float _playerDefaultSpeed;

    private Coroutine _dangerCoroutine;
    protected override void Start()
    {
        base.Start();
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
            _anim.SetBool("Enemy Bend Over", true);
            playerController.SetMoveSpeed(playerController.SlowSpeed);
            Agent.speed = 0f;
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
            _anim.SetBool("Enemy Bend Over", false);
            playerController.SetMoveSpeed(_playerDefaultSpeed);
            Agent.speed = 0.5f;
            StopCoroutine(_dangerCoroutine);
            _dangerCoroutine = null;
        }
    }
    private IEnumerator Danger()
    {

        fov.color = Color.black;
        yield return null;
    }
}