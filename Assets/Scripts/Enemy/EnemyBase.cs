using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] GameObject enemyFace;
    [SerializeField] GameObject gameOver;
    protected Animator _anim;
    protected NavMeshAgent Agent { get; private set; }
    protected virtual void Start()
    {
        gameOver.SetActive(false);
        _anim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        if (Agent == null)
        {
            Debug.LogError("NavMesh‚ª‚È‚¢");
        }
    }
    public void GameOver()
    {
        gameOver.SetActive(true);

    }
}
