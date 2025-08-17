using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextWrite : MonoBehaviour
{
    [Header("読み込むためのテキスト")]
    [SerializeField] private TextMeshProUGUI keyName;
    [SerializeField] private TextMeshProUGUI keyExplation;

    [Header("読み込む速度")]
    [SerializeField] private float writeSpeed;

    private Coroutine _coroutine;

    /// <summary>
    /// 文字送りの演出
    /// </summary>
    public void Write()
    {
        //前回の処理が走っていたら停止
        if (_coroutine != null)
        {
            StopCoroutine(ShowCoroutine());
        }

        _coroutine = StartCoroutine(ShowCoroutine());
    }
    private IEnumerator ShowCoroutine()
    {
        //次の文字を表示させるための待機時間
        var delay = new WaitForSeconds(writeSpeed);
        
        //テキスト全体の長さ
        var nameLength = keyName.text.Length;
        var explanationLength = keyExplation.text.Length;

        //一文字ずつ表示する
        for (int i = 0; i < explanationLength; i++)
        {

            keyExplation.maxVisibleCharacters = i;
            keyName.maxVisibleCharacters = i;

            //一定時間待機
            yield return delay;
        }

        keyName.maxVisibleCharacters = nameLength;
        keyExplation.maxVisibleCharacters = explanationLength;

        _coroutine = null;
    }
}