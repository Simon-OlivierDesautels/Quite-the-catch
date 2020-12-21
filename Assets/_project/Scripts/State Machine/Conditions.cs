using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Conditions : ScriptableObject
{
    protected FiniteStateMachine fsm;

    public abstract void OnStart();


    public abstract void UpdateConditions();

    #region -Setters-

    public void SetStateMachine(FiniteStateMachine stateMachine)
    {
        fsm = stateMachine;
    }

    #endregion
}