using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected GameObject destination;
    protected NavMeshAgent Agent { get; private set; }
    protected virtual void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        if (Agent == null)
        {
            Debug.LogError("NavMesh‚ª‚È‚¢");
        }
    }
}
