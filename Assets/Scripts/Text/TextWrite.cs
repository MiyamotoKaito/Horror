using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextWrite : MonoBehaviour
{
    [Header("読み込むためのテキスト")]
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI explationText;

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
        var nameLength = nameText.text.Length;
        var explanationLength = explationText.text.Length;

        var maxLength = Mathf.Max(nameLength, explanationLength);

        //一文字ずつ表示する
        for (int i = 0; i < maxLength; i++)
        {
            nameText.maxVisibleCharacters = Mathf.Min(i, nameLength);
            explationText.maxVisibleCharacters = Mathf.Min(i, explanationLength);

            //一定時間待機
            yield return delay;
        }

        // 最終的に全文字を表示
        nameText.maxVisibleCharacters = nameLength;
        explationText.maxVisibleCharacters = explanationLength;

        _coroutine = null;
    }
}