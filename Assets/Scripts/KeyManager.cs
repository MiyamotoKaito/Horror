using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance { get; private set; }

    private HashSet<int> _onwnedKeys = new HashSet<int>();

    public System.Action<KeyBase> OnkeyObtaind;//Œ®‚ðŽæ“¾
    public System.Action<KeyBase> OnkeyUsed;//Œ®‚ðŽd—l

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
    /// Œ®‚ðŽæ“¾
    /// </summary>
    /// <param name="Keytype"></param>
    public void ObtaindKey(KeyBase Keytype)
    {
        if (_onwnedKeys.Add(KeyBase._keyID))
        {

        }
    }
}