﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle,
    Walk,
    Run,
    Jump,
    Land
}


public abstract class State : ScriptableObject
{
    protected FiniteStateMachine fsm;
    protected StateType _stateType;
    
    
    public virtual void OnEntering()
    {
        
    }

    public abstract void UpdateState();

    
    #region -Setters-

    public void SetStateMachine(FiniteStateMachine stateMachine)
    {
        fsm = stateMachine;
    }

    #endregion
    
}