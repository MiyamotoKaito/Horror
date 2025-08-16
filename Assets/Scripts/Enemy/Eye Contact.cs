using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeContact : MonoBehaviour
{
    [SerializeField] GameObject enemyFace;
    [SerializeField] GameObject gameOver;
    void Start()
    {
        gameOver.SetActive(false);
    }
    public void GameOver()
    {
        StartCoroutine(Noise());
    }
    IEnumerator Noise()
    {
        gameOver.SetActive(true);
        yield return new WaitForSeconds(2f);
    }
}
