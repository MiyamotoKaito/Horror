using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "KeyDeta", menuName = "KeySystem/KeyDeta")]
public class KeyBase : ScriptableObject
{
    public string _keyName;
    public Color _tagColor;
    public GameObject _prefab;
    public int _keyID;
}