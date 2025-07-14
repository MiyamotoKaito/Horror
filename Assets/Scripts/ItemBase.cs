using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyDeta", menuName = "KeyDeta/KeyDeta")]
public class KeyBase : ScriptableObject
{
    public List<Key> KeyLIst = new List<Key>();
}

[System.Serializable]
public class Key
{
    public string KeyName = "Мо";

}