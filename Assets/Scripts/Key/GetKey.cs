using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    [SerializeField] private KeyBase keyType;
    [SerializeField] private static List<KeyType> keys = new List<KeyType>();
    private bool canGetKey;

    public KeyBase KeyType { get => keyType; set => keyType = value; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canGetKey)
        {
            keys.Add(KeyType.keyID);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canGetKey = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canGetKey = false;
        }
    }
    public static bool HasKey(KeyType keyID)
    {
        return keys.Contains(keyID);//特定のキーを持っているかチェックするメソッド
    }
}