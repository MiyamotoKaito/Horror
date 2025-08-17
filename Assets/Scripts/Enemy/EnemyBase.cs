using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    protected Animator _anim;
    protected NavMeshAgent Agent { get; private set; }
    protected virtual void Start()
    {
        _anim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        if (Agent == null)
        {
            Debug.LogError("NavMeshがない");
        }
    }
}
