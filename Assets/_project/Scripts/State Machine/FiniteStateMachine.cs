using System;
using System.Collections;
using System.Collections.Generic;
using _project.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class FiniteStateMachine : MonoBehaviour
{
    [Header("States")]
    [SerializeField] private State[] validStates;
    
    [Header("Conditions")]
    [SerializeField] private Conditions conditions;

     private State _currentState;
     private State _nextState;

    public Human HumanP { get; private set; }
    
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
                _nextState = state;
            }
        }

        SetState(_nextState);
    }

    private void DefineConditionsParent()
    {
        if (GetComponent<Human>()) HumanP = GetComponent<Human>();
    }

    public void LockState(string stateLocked)
    {
        StartCoroutine(stateLocked);
    }
    
    IEnumerator LockCatch()
    {
        HumanP.CanJump = false;
        yield return new WaitForSeconds(0.00000000001f);
        float delay = HumanP.Animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(delay);
        HumanP.CanJump = true;
        HumanP.PlayerCatching = false;
    }
}