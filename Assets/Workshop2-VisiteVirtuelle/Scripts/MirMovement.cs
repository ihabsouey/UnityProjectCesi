using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class MirMovement : NetworkBehaviour
{
    private CharacterController m_characterController ;

    public Transform goal;

    void Start()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
    }


    void Update()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;


    }

    [ServerRpc(RequireOwnership = false)]
    public void ChangeGoalPositionServerRpc(Vector3 pos )
    {
         goal.position = pos;
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = pos;
    }
}
