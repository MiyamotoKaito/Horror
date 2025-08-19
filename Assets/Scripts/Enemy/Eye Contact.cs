using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EyeContact : MonoBehaviour
{
    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private float noiseTime;
    private bool isPlayerLook;

    void Awake()
    {
        Debug.Log("awaaw");
        gameOver.SetActive(false);
    }
    public void GameOver()
    {
        if (isPlayerLook == true)
        {
            return;
        }
        StartCoroutine(Noise());
    }
    IEnumerator Noise()
    {
        gameOver.SetActive(true);
        AudioManager.Instance.PlaySE("砂嵐", playerAudioSource);
        isPlayerLook = true;
        yield return new WaitForSeconds(noiseTime);
        gameOver.SetActive(false);
        ghost.SetActive(false);
        AudioManager.Instance.StopAudio(playerAudioSource);
    }
}