using UnityEngine;
[CreateAssetMenu(fileName = "KeyDeta", menuName = "KeySystem/KeyDeta")]
public class KeyBase : ScriptableObject
{
    public string _keyName;
    public Color _tagColor;
    public GameObject _prefab;
    public KeyType _keyID;
    
}
public enum KeyType
{
    RedKey,
    GreenKey,
    BlueKey,
}
