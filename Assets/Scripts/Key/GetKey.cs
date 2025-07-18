using UnityEngine;

public class GetKey : MonoBehaviour
{
    public static bool _getKey;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _getKey = true;
            gameObject.SetActive(false);
        }
    }
}
