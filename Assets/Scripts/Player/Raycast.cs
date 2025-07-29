using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] KeyBase keyType;
    [SerializeField] Text explanation;
    private Vector3 origin = new Vector3(0, 0, 0);
    public Vector3 direction = new Vector3(1, 0, 0);
    void Start()
    {

    }
    void Update()
    {
        Ray ray = new Ray(origin, direction);
        Raycast hit = GetComponent<Raycast>();
        if (hit.CompareTag("Key"))
        {
            explanation.text = keyType.explanation;
        }
    }
}