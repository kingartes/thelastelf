using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;


public class State
{
    public StateID StateID { get; private set; }
    public string StateName { get; private set; }

    public event Action OnExitRequested;

    public State(string stateName)
    {
        this.StateName = stateName;
    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnLogic()
    {

    }

    public virtual void OnExit()
    {

    }

    public void RequestExit()
    {
        OnExitRequested?.Invoke();
    }
}

