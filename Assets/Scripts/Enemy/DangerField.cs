using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DangerField : EnemyBase
{
    [SerializeField] Image image;
    public Animator anim;
    public PlayerController playerController;
    private void Start()
    {
        image.color = Color.clear;
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        image.color = Color.Lerp(image.color, Color.clear, Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0.2f;
            Agent.speed = 0f;
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

