using System.Collections;
using System.Collections.Generic;
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

    public void WriteText()
    {
        //前回の処理が走っていたら停止
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}
