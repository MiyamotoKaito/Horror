using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    public GameObject destination;
    public static NavMeshAgent Agent { get; private set; }

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Agent.SetDestination(destination.transform.position);
    }
}
