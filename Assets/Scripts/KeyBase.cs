using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "KeyDeta", menuName = "KeySystem/KeyDeta")]
public class KeyBase : ScriptableObject
{
    public string _keyName;
    public Color _tagColor;
    public Texture _tagImage;
    public int _keyID;
}