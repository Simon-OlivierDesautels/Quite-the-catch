using System;
using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Animations
    enum Animation
    {
        Idle,
        Walk,
        Run,
        Jump,
        Land,
        Catch
    };

    [SerializeField] private Animation _currentAnimation;
    [SerializeField] private float _runningSpeed;

    private float _horizontalInput;
    private float _playerWidth;
    private bool _facingRight;
   [SerializeField] private bool _endOfTrigger;
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
        VerticalMovementAnimation();
    }

    //------------------------------------- Horizontal Movement Animation ----------------------------------------------
    private void HorizontalMovementAnimation()
    {
        _horizontalInput = CurrentPlayer.PlayerAxis;
        SwitchDirection();
        switch (CurrentPlayer.PlayerGrounded)
        {
            case true:
                Catch();
                if (CurrentPlayer.PlayerCatching) return;
                Idle();
                Walk();
                Run();
                break;
            case false:
                return;
        }
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
    
    //-------------------------------------- Vertical Movement Animation -----------------------------------------------
    private void VerticalMovementAnimation()
    {
        switch (!CurrentPlayer.PlayerGrounded)
        {
            case true:
                Jump();
                Land();
                break;
            case false:
                return;
        }
    }

    private void Jump()
    {
        if (!(CurrentPlayer.Rigidbody2D.velocity.y > 0)) return;
        ChangeAnimationState(Animation.Jump.ToString());
        _currentAnimation = Animation.Jump;
        CurrentPlayer.PlayerRunning = true;
    }

    private void Land()
    {
        if (!(CurrentPlayer.Rigidbody2D.velocity.y < 0)) return;
        ChangeAnimationState(Animation.Land.ToString());
        _currentAnimation = Animation.Land;
        CurrentPlayer.PlayerRunning = true;
        CurrentPlayer.PlayerFalling = true;
    }

    private void Catch()
    {
        if (!CurrentPlayer.PlayerCatching) return;
        ChangeAnimationState(Animation.Catch.ToString());
        _currentAnimation = Animation.Catch;
        if (!_endOfTrigger) StartCoroutine(StopCatching());
    }

    IEnumerator StopCatching()
    {
        _endOfTrigger = true;
        yield return new WaitForSeconds(0.00001f);
        float delay = Animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(delay);
        _endOfTrigger = false;
        CurrentPlayer.PlayerCatching = false;
    }
    
    private void ChangeAnimationState(string newAnimation)
    {
        if (_currentAnimaton == newAnimation) return;
        Animator.Play(newAnimation);
        _currentAnimaton = newAnimation;
    }
}