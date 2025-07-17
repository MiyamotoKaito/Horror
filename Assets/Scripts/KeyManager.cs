using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance { get; private set; }
    //HashSet�ō�������
    private HashSet<int> _onwnedKeys = new HashSet<int>();
    //�C�x���g�V�X�e�����g����
    public System.Action<KeyBase> OnkeyObtaind;//�����擾
    public System.Action<KeyBase> OnkeyUsed;//�����d�l
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
    /// �����擾
    /// </summary>
    /// <param name="Keytype"></param>
    public void ObtaindKey(KeyBase Keytype)
    {
        if (_onwnedKeys.Add(Keytype._keyID))
        {
            OnkeyObtaind?.Invoke(Keytype);
            Debug.Log($"�����擾:{Keytype._keyName}");
        }
    }
    /// <summary>
    /// ���������Ă��邩�m�F
    /// </summary>
    /// <returns></returns>
    public bool HasKey(KeyBase keytype)
    {
        return _onwnedKeys.Contains(keytype._keyID);
    }
    /// <summary>
    /// ���̎g�p
    /// </summary>
    /// <param name="keytype"></param>
    /// <returns></returns>
    public bool IsKeyUsed(KeyBase keytype)
    {
        OnkeyUsed?.Invoke(keytype);
        return true;
    }
}