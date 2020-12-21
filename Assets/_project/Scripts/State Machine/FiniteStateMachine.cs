using System;
using System.Collections;
using System.Collections.Generic;
using _project.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField] private State[] validStates;
    private State _currentState;
    private State _nextState;

    private void Start()
    {
        foreach (var state in validStates)
        {
            state.SetStateMachine(this);
        }
        
   //     SetState(StateType.Idle);
    }
    
    private void Update()
    {
    //    if (_currentState) 
    }

    public void SetState(StateType state)
    {
        StateType nextStateType = state;
    }
    
    
}