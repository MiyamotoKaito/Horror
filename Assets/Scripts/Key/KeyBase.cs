using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
[CreateAssetMenu(fileName = "KeyDeta", menuName = "KeySystem/KeyDeta")]
public class KeyBase : ScriptableObject
{
    public string keyName;
    public string explanation;
    public KeyType keyID;
}