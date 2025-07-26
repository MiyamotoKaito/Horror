using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    public GameObject destination;
    public static NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        _agent.SetDestination(destination.transform.position);
    }
}
