using System;
using System.Collections;
using System.Collections.Generic;
using _project.Scripts;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    protected State State;
    [SerializeField] private InputReader _inputReader2;

    enum Days {Catch, Jump, Land, Tue, Wed, Thu, Fri}

    [SerializeField] private string _state;
    public void SetState(State state)
    {
        State = state;
        StartCoroutine(State.Start());
    }

    private void Catch()
    {
        _state = Days.Catch.ToString();
    }
    private void Jump()
    {
        _state = Days.Jump.ToString();
    }

    private void OnEnable()
    {
        _inputReader2.CatchEvent += Catch;
        _inputReader2.JumpEvent += Jump;
//        _inputReader.MoveEvent += Walk;
//        _inputReader.MoveEvent += SwitchDirection;
    }

    private void OnDisable()
    {
        _inputReader2.CatchEvent -= Catch;
        _inputReader2.JumpEvent -= Jump;
//        _inputReader.MoveEvent -= Run;
 //       _inputReader.MoveEvent -= Walk;
 //       _inputReader.MoveEvent -= SwitchDirection;
    }
}
