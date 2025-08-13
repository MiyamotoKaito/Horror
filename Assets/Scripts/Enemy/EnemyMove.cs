using UnityEngine;

public class EnemyMove : EnemyBase
{
    [SerializeField] protected GameObject destination;
    protected override void Start()
    {
        base.Start();
    }
    public void Update()
    {
        Agent.SetDestination(destination.transform.position);
        _anim.SetFloat("EnemyMove", Agent.speed);
    }
}
