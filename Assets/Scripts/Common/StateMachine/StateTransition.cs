using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class StateTransition
{
    private Func<bool> condition;
    private State targetState;
    public State SourceState { get; private set; }

    public StateTransition(State sourceState, State targetState, Func<bool> condition)
    {
        this.SourceState = sourceState;
        this.targetState = targetState;
        this.condition = condition;
    }

    public bool TryEnterState(out State state)
    {
        state = null;
        if (condition() ){  
            state = targetState;
            return true;
        }
        return false;
    }
}
