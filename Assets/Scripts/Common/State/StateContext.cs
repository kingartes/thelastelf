using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateContext : MonoBehaviour
{
    private State currentState;
    private List<StateTransition> transitionList;

    protected virtual void Update()
    {
        currentState.OnUpdate();
        CheckTransitions();
    }

    private void CheckTransitions()
    {
        foreach (var transition in transitionList)
        {
            if (transition.TryEnterState(out State targetState)) {
                EnterState(targetState);
                return;
            }
        }
    }

    private void EnterState(State targetState)
    {
        currentState.Exit();
        currentState = targetState;
        currentState.Enter();
    }
}
