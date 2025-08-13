using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private GameObject destination;
    protected NavMeshAgent Agent { get; private set; }
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Agent.SetDestination(destination.transform.position);
    }
}
