using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
[CreateAssetMenu(fileName = "KeyData", menuName = "KeySystem/KeyData")]
public class KeyBase : ScriptableObject
{
    public string keyName;
    [TextArea(5,10)]
    public string explanation;
    public KeyType keyID;
    public GameObject KeyObject;
}