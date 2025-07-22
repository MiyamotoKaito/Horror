using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    [SerializeField] KeyBase keyType;
    [SerializeField] static List<KeyType> keys = new List<KeyType>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keys.Add(keyType.keyID);
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    public static bool HasKey(KeyType keyID)
    {
        return keys.Contains(keyID);//特定のキーを持っているかチェックするメソッド
    }
}
