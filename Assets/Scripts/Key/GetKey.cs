using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    [SerializeField] KeyBase keyType;
    [SerializeField] static List<KeyType> keys = new List<KeyType>();
    void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F) && other.CompareTag("Player"))
        {
            keys.Add(keyType.keyID);
            Destroy(gameObject);
        }
    }
    public static bool HasKey(KeyType keyID)
    {
        return keys.Contains(keyID);//����̃L�[�������Ă��邩�`�F�b�N���郁�\�b�h
    }
}
