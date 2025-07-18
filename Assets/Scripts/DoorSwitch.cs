using UnityEngine;
using UnityEngine.Events;
public class DoorSwitch : MonoBehaviour
{
    [SerializeField] UnityEvent _actions;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _actions.Invoke();
        }
    }
}
