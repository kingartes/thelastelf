using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class State
{
    protected StateContext context;
    protected List<StateTransition> transitionList;

    public State(StateContext context) {
        this.context = context;
        transitionList = new List<StateTransition>();
    }

    public void SetupStansitions(List<StateTransition> transitions)
    {
        transitionList.AddRange(transitions);
    }

    public abstract void Enter();

    public virtual void OnUpdate()
    {
        Debug.Log(this);
        CheckTransitions();
    }
    public abstract void Exit();

    protected virtual void CheckTransitions()
    {
        foreach (var transition in transitionList)
        {
            if (transition.TryEnterState(out State targetState))
            {
                context.EnterState(targetState);
                return;
            }
        }
    }


}
