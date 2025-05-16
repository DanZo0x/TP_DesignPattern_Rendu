using System;
using UnityEngine;
using UnityEngine.AI;

public class PatrollState : State
{
    public float speedWhenPatrolling = 2f;

    public float radius = 4f;
    private Vector3 startPos;

    public bool returnToBase;

    NavMeshAgent agent;


    public State runToPlayer;

    public  float timer = 0;
    public float roamTimer = 3;
    public override void StateInit(StateMachine sm)
    {
        base.StateInit(sm);
        agent = GetComponent<NavMeshAgent>();
        startPos = transform.position;

    }

    public override void StateEnter()
    {
        base.StateEnter();
        timer = UnityEngine.Random.Range(0f,roamTimer);
    }

    public override void StateUpdate()
    {
        timer += Time.deltaTime;
        if (Vector3.Distance(transform.position, startPos) > radius)
        {
            returnToBase = true;
        }
        else if (!returnToBase && timer > roamTimer) //Roaming
        {
            timer = 0;
            Vector3 newPos = RandomNavSphere(transform.position, radius, -1);
            agent.SetDestination(newPos);
        }

        if (returnToBase)
        {
            timer = 0;
            agent.SetDestination(startPos);

            if (Vector3.Distance(transform.position, startPos) < .2f) returnToBase = false; 
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (!this.enabled)
        {
            return;
        }
        if(other.CompareTag("Player"))
        _StateMachine.ChangeState(runToPlayer);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;
        randDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        navHit.position = new(navHit.position.x, 0, navHit.position.z);

        return navHit.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(startPos, radius);
    }
}
