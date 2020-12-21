using System;
using System.Collections;
using System.Collections.Generic;
using _project.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField] private State[] validStates;
    [SerializeField] private Conditions conditions;

    [SerializeField] private State _currentState;

    public Human HumanP { get; private set; }


    private State _nextState;

    private void Start()
    {
    
        conditions.SetStateMachine(this);
        conditions.OnStart();
        DefineConditionsParent();
        
        foreach (var state in validStates)
        {
            state.SetStateMachine(this);
            state.OnStart();
        }
    }

    private void Update()
    {
        if (_currentState == _nextState)
        {
            _currentState.UpdateState();
            conditions.UpdateConditions();
        }

        else
        {
            _currentState = _nextState;
            _nextState.OnEntering();
        }
    }

    private void SetState(State state)
    {
        _nextState = state;
    }

    public void DefineState(StateType stateType)
    {
        StateType nextStateType = stateType;

        foreach (var state in validStates)
        {
            if (state._stateType == nextStateType)
            {
                Debug.Log(state);
                _nextState = state;
            }
            else return;
        }

        SetState(_nextState);
    }

    private void DefineConditionsParent()
    {
        if (GetComponent<Human>()) HumanP = GetComponent<Human>();
    }
}