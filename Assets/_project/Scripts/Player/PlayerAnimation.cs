using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Animations
    enum Animation
    {
        Idle,
        Walk,
        Run
    };

    [SerializeField] private Animation _currentAnimation;
    [SerializeField] private float _runningSpeed;

    private float _horizontalInput;
    private float _playerWidth;
    private bool _facingRight;
    private string _currentAnimaton;

    private Animator Animator;
    private Human CurrentPlayer;

    void Start()
    {
        Animator = GetComponent<Animator>();
        CurrentPlayer = GetComponent<Human>();
        _playerWidth = transform.localScale.x;
    }


    private void Update()
    {
        HorizontalMovementAnimation();
    }

    //------------------------------------- Horizontal Movement Animation ----------------------------------------------
    private void HorizontalMovementAnimation()
    {
        _horizontalInput = CurrentPlayer.PlayerAxis;
        switch (CurrentPlayer.PlayerGrounded)
        {
            case true:
                Idle();
                Walk();
                Run();
                break;
            case false:
                return;
        }
        
        SwitchDirection();
    }

    private void Idle()
    {
        if (Math.Abs(_horizontalInput) > 0) return;
        ChangeAnimationState(Animation.Idle.ToString());
        _currentAnimation = Animation.Idle;
        CurrentPlayer.PlayerRunning = false;
    }

    private void Walk()
    {
        if (_horizontalInput < -_runningSpeed || _horizontalInput > _runningSpeed) return;
        if (Math.Abs(_horizontalInput) > 0)
        {
            ChangeAnimationState(Animation.Walk.ToString());
            _currentAnimation = Animation.Walk;
            CurrentPlayer.PlayerRunning = false;
        }
    }

    private void Run()
    {
        if (!(_horizontalInput < -_runningSpeed) && !(_horizontalInput > _runningSpeed)) return;
        ChangeAnimationState(Animation.Run.ToString());
        _currentAnimation = Animation.Run;
        CurrentPlayer.PlayerRunning = true;
    }

    private void SwitchDirection()
    {
        if (_horizontalInput > 0) _facingRight = true;
        else if (_horizontalInput < 0) _facingRight = false;
        if (!_facingRight) transform.localScale = new Vector3(-_playerWidth, transform.localScale.y, transform.localScale.z);
        else transform.localScale = new Vector3(_playerWidth, transform.localScale.y, transform.localScale.z);
    }

    private void ChangeAnimationState(string newAnimation)
    {
        if (_currentAnimaton == newAnimation) return;
        Animator.Play(newAnimation);
        _currentAnimaton = newAnimation;
    }
}