using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;

    List<State> allStates = new();

    private void Awake()
    {
        allStates = GetComponents<State>().ToList();
        foreach (var state in allStates)
        {
            state.StateInit(this);
            state.enabled = false;
        }
        if (currentState is null) currentState = allStates[0];

        currentState.StateEnter();
    }
    void Update()
    {
        if (currentState is not null && currentState.HasStarted && currentState.IsInit) currentState.StateUpdate();
    }

    public void ChangeState(State newState = null)
    {
        if (newState == null) { newState = allStates[0]; }
        currentState.StateExit();
        currentState = newState;
        currentState.StateEnter();
    }
}
