using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class StateMachine<TEntity> where TEntity: MonoBehaviour
{
    protected Stack<State> stateStack;
    protected Dictionary<string, State> states;
    protected List<StateTransition> transitions;
    protected Func<IEnumerator, Coroutine> startCoroutine;
    protected string entryStateName;


    protected State CurrentState => stateStack.Peek();
    private List<StateTransition> CurrentStateTransition => transitions.Where(t => t.SourceState.StateName == CurrentState.StateName || t.SourceState.StateName == StatesList.ANY_STATE).ToList();

    public StateMachine(string entryStateName) {
        this.entryStateName = entryStateName;
    }

    public void Init()
    {
        transitions = new List<StateTransition>();
        states = InitializeStates();
        stateStack = new Stack<State> { };
        stateStack.Push(states[entryStateName]);
        CurrentState.OnEnter();
        
    }

    public virtual void OnLogic()
    {
      //  Debug.Log(CurrentState);
        CheckTransitions();
        stateStack.Peek().OnLogic();
    }

    protected void AddTransition(State sourceState, State targetState, Func<bool> condition)
    {
        transitions.Add(new StateTransition(sourceState, targetState, condition));
    }

    protected virtual Dictionary<string, State> InitializeStates()
    {
        return new Dictionary<string, State> { };
    }

    protected void EnterState(State state)
    {
        CurrentState.OnExit();
        CurrentState.OnExitRequested -= CurrentState_OnExitRequested;
        stateStack.Push(state);
        CurrentState.OnEnter();
        CurrentState.OnExitRequested += CurrentState_OnExitRequested;
    }

    protected void ExitState()
    {
        CurrentState.OnExit();
        CurrentState.OnExitRequested -= CurrentState_OnExitRequested;
        stateStack.Pop();
        CurrentState.OnEnter();
        CurrentState.OnExitRequested += CurrentState_OnExitRequested;
    }

    protected void CheckTransitions()
    {
        foreach (var transition in CurrentStateTransition)
        {
            if (transition.TryEnterState(out State targetState))
            {
                EnterState(targetState);
                return;
            }
        }
    }

    private void CurrentState_OnExitRequested()
    {
        ExitState();
    }
}

