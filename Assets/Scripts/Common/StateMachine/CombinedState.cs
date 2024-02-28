using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CombinedState : State
{
    protected List<State> states;
    public CombinedState(string stateName, List<State> states) : base(stateName)
    {
        this.states = states;
    }

    public override void OnLogic()
    {
        base.OnLogic();
        foreach(var state in states)
        {
            state.OnLogic();
        }
    }
}

