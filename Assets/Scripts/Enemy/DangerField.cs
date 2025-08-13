using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DangerField : EnemyBase
{
    [SerializeField] Image image;
    [SerializeField] private PlayerController _playerController;
    private Animator _anim;
    private void Start()
    {
        image.color = Color.clear;
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        image.color = Color.Lerp(image.color, Color.clear, Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerController.SetMoveSpeed(1f);
            Agent.speed = 0f;
            StartCoroutine(Danger(1f));
            //anim.Play("Down");
        }
        if (other.CompareTag("Destination"))
        {
            Debug.Log("óHóÏÇ™è¡Ç¶ÇΩ");
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Agent.speed = 0.5f;
            StopCoroutine(Danger(1f));
        }
    }
    private IEnumerator Danger(float second)
    {
        image.color = new Color(1f, 0, 0, 1f);
        yield return new WaitForSeconds(second);
    }
}

