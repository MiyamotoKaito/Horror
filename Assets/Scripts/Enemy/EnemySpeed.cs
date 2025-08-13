using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeed : EnemyBase
{
    public void Update()
    {
        Agent.SetDestination(destination.transform.position);
    }
}
