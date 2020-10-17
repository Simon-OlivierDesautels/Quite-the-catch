using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Human ParentClass;
    [SerializeField] private CoopInputManager _inputs;
    private List<String> _inputList;
    private string _controlHorizontal;
    private string _controlJump;
    
    private void Start()
    {
        ParentClass = GetComponent<Human>();
        _inputList = _inputs.ReturnInputs();
        _controlHorizontal = _inputList[0];
        _controlJump = _inputList[1];
    }

    private void Update()
    {
        ParentClass.PlayerAxis = Input.GetAxis(_controlHorizontal);
        if (Input.GetButtonDown(_controlJump) && ParentClass.PlayerGrounded) ParentClass.PlayerJumping = true;
    }
}
