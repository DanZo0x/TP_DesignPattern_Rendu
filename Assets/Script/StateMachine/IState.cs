using UnityEngine;

public interface IState
{
    public bool HasStarted { get; set; }
    public bool IsInit { get; set; }
    public StateMachine _StateMachine { get; set; }

    public abstract void StateInit(StateMachine sm);
    public abstract void StateEnter();
    public abstract void StateUpdate();
    public abstract void StateExit();

}
