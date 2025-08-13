using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected GameObject destination;
    protected NavMeshAgent Agent { get; private set; }
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Agent == null)
        {
            Debug.LogError("NavMesh‚ª‚È‚¢");
        }
    }
}
