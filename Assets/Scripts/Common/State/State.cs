using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
  public virtual void Enter()
    {
        // State enter here
    }

   public virtual void OnUpdate()
    {
        /// State behavior here;
    }

    public virtual void Exit()
    {
        // State exit here;
    }
}
