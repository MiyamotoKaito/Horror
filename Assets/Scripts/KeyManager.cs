using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance { get; private set; }
    //HashSetで高速検索
    private HashSet<int> _onwnedKeys = new HashSet<int>();
    //イベントシステムを使って
    public System.Action<KeyBase> OnkeyObtaind;//鍵を取得
    public System.Action<KeyBase> OnkeyUsed;//鍵を仕様
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// 鍵を取得
    /// </summary>
    /// <param name="Keytype"></param>
    public void ObtaindKey(KeyBase Keytype)
    {
        if (_onwnedKeys.Add(Keytype._keyID))
        {
            OnkeyObtaind?.Invoke(Keytype);
            Debug.Log($"鍵を取得:{Keytype._keyName}");
        }
    }
    /// <summary>
    /// 鍵を持っているか確認
    /// </summary>
    /// <returns></returns>
    public bool HasKey(KeyBase keytype)
    {
        return _onwnedKeys.Contains(keytype._keyID);
    }
    /// <summary>
    /// 鍵の使用
    /// </summary>
    /// <param name="keytype"></param>
    /// <returns></returns>
    public bool IsKeyUsed(KeyBase keytype)
    {
        OnkeyUsed?.Invoke(keytype);
        return true;
    }
}