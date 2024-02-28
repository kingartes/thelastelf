using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class State_Deprecated

{
    protected StateContext_Deprecated context;
    protected List<StateTransition_Deprecated> transitionList;

    public State_Deprecated(StateContext_Deprecated context) {
        this.context = context;
        transitionList = new List<StateTransition_Deprecated>();
    }

    public void SetupStansitions(List<StateTransition_Deprecated> transitions)
    {
        transitionList.AddRange(transitions);
    }

    public abstract void Enter();

    public virtual void OnUpdate()
    {
        CheckTransitions();
    }
    public abstract void Exit();

    protected virtual void CheckTransitions()
    {
        foreach (var transition in transitionList)
        {
            if (transition.TryEnterState(out State_Deprecated targetState))
            {
                context.EnterState(targetState);
                return;
            }
        }
    }


}
