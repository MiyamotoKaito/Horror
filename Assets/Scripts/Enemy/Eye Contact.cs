using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeContact : MonoBehaviour
{
    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject gameOver;
    private bool isTrigger;

    void Awake()
    {
        Debug.Log("awaaw");
        gameOver.SetActive(false);
    }
    public void GameOver()
    {
        if (isTrigger == true)
        {
            return;
        }
        StartCoroutine(Noise());
    }
    IEnumerator Noise()
    {
        gameOver.SetActive(true);
        AudioManager.Instance.SEPlay("砂嵐");
        isTrigger = true;
        yield return new WaitForSeconds(2f);
        gameOver.SetActive(false);
        ghost.SetActive(false);
        AudioManager.Instance.BGMStop();
    }
}
