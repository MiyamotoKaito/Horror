using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    public GameObject destination;
    private static NavMeshAgent agent;
    public static NavMeshAgent Agent { get => agent; set => agent = value; }

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Agent.SetDestination(destination.transform.position);
    }
}
