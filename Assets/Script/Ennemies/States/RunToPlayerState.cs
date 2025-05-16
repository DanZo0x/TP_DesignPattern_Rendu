using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class RunToPlayerState : State
{
    public float Speed = 4f;
    public float MaxRangeToRun = 7f;
    public Transform player;

    NavMeshAgent agent;

    public override void StateInit(StateMachine sm)
    {
        base.StateInit(sm);
        player = GameManager.Instance.GetPlayer;
        agent = GetComponent<NavMeshAgent>();

        IStats stats = GetComponent<IStats>();
        Speed = stats.CalculateStat((int)Speed, stats.Spe);

        agent.speed = Speed;
    }
    public override void StateEnter()
    {
        base.StateEnter();

        agent.speed = Speed;
        agent.SetDestination(player.position);
    }
    public override void StateUpdate()
    {
        if (Vector3.Distance(transform.position, player.position) > MaxRangeToRun)
        {
            _StateMachine.ChangeState(null);
        }

        agent.SetDestination(player.position);

    }

}
