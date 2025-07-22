using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    [SerializeField] KeyBase keyType;
    [SerializeField] static List<KeyType> keys = new List<KeyType>();
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            keys.Add(keyType.keyID);
            gameObject.SetActive(false);
        }
    }
    public static bool HasKey(KeyType keyID)
    {
        return keys.Contains(keyID);//特定のキーを持っているかチェックするメソッド
    }
}
