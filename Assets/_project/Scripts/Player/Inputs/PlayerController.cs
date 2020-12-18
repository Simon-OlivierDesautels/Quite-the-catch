using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [Header("Input Settings")]
    [SerializeField] private PlayerInput playerInput;
    private PlayerInputActions _playerInputActions;
    private PlayerMovement _playerMovement;
    private Human _parentClass;
    private string actionMapPlayerControls = "Player Controls";
    private string actionMapMenuControls = "Menu Controls";
    

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();

        // _playerInputActions.PlayerControls.Jump.performed += context => Jump();
        // _playerInputActions.PlayerControls.Movement.performed += context => Move();
        // _playerInputActions.PlayerControls.Catch.performed += context => Catch();


        _parentClass = GetComponent<Human>();
        _playerMovement = GetComponent<PlayerMovement>();
    }
    public void Move()
    {
        _parentClass.PlayerAxis = _playerInputActions.PlayerControls.Movement.ReadValue<float>();
    }
    public void Jump(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            _playerMovement.VerticalMovement();
        }
    }
    public void Catch()
    {
        _parentClass.PlayerCatching = true;
    }
    public void OnpPause(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            GameManager.Instance.TogglePauseState(this);
        }
    }

    public void EnableGameplayControls()
    {
        playerInput.SwitchCurrentActionMap(actionMapPlayerControls);  
    }

    public void EnablePauseMenuControls()
    {
        playerInput.SwitchCurrentActionMap(actionMapMenuControls);
    }

    #region -Enable/disable-

    private void OnEnable()
    {
        _playerInputActions.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Disable();
    }

    #endregion
}