public class EnemyMove : EnemyBase
{
    protected override void Start()
    {
        base.Start();
    }
    public void Update()
    {
        Agent.SetDestination(destination.transform.position);
    }
}
