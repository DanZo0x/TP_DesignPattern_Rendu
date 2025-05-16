using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour, IState
{
    public bool HasStarted { get => hasStarted; set => hasStarted = value; }
    public StateMachine _StateMachine { get => stateMachine; set => stateMachine = value; }
    public bool IsInit { get => isInit; set => isInit = value; }

    bool isInit = false;

    bool hasStarted = false;

    StateMachine stateMachine;
    public virtual void StateEnter()
    {
        Debug.Log(this.GetType() + " Enter");
        hasStarted = true;
        this.enabled = true;
    }

    public virtual void StateExit()
    {
        Debug.Log(this.GetType() + " Exit");
        this.enabled = false;

    }

    public abstract void StateUpdate();

    public virtual void StateInit(StateMachine sm)
    {
        _StateMachine = sm;
        isInit = true;
    }
}
