using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DangerField : EnemyBase
{
    [SerializeField] Image _image;
    public Animator anim;
    public PlayerController playerController;
    private void Start()
    {
        _image.color = Color.clear;
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        _image.color = Color.Lerp(_image.color, Color.clear, Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0.2f;
            _agent.speed = 0f;
            StartCoroutine(Danger(1f));
            //anim.Play("Down");
        }
        if (other.CompareTag("Destination"))
        {
            Debug.Log("Š÷‚É“–‚½‚Á‚½");
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 1f;
            _agent.speed = 0.5f;
            StopCoroutine(Danger(1f));
        }
    }
    private IEnumerator Danger(float second)
    {
        _image.color = new Color(1f, 0, 0, 1f);
        yield return new WaitForSeconds(second);
    }
}

