using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLockedArea : MonoBehaviour
{
    [SerializeField] GameObject lockedArea;
    [SerializeField] GameObject movePos;

    public void MoveArea()
    {
        lockedArea.transform.position = movePos.transform.position;
    }
}
