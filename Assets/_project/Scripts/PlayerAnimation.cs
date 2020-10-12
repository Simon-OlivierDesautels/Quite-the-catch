using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Animations
    enum Animation
    {
        Walk,
        Idle,
        Run
    };

    //Variables
    [SerializeField] private float _runningSpeed;
    private float _horizontalInput;
    private bool _facingRight = false;
    private string _currentAnimaton;

    //Component
    private Animator Animator;
    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D Rigidbody2D;
    private Human CurrentPlayer;

    void Start()
    {
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        CurrentPlayer = GetComponent<Human>();
    }

    void Update()
    {
        HorizontalMovementAnimation();
    }

    //------------------------------------- Horizontal Movement Animation ----------------------------------------------
    private void HorizontalMovementAnimation()
    {
        _horizontalInput = CurrentPlayer.PlayerAxis;

        Walk();
        Run();
        FlipSprite();
    }

    private void Walk()
    {
        if (_horizontalInput < -_runningSpeed || _horizontalInput > _runningSpeed) return;
        if (_horizontalInput != 0)
        {
            ChangeAnimationState(Animation.Walk.ToString());
            CurrentPlayer.Running = false;
        }
        else ChangeAnimationState(Animation.Idle.ToString()); CurrentPlayer.Running = false;
    }

    private void Run()
    {
        if (_horizontalInput < -_runningSpeed || _horizontalInput > _runningSpeed)
        {
            {
                ChangeAnimationState(Animation.Run.ToString());
                CurrentPlayer.Running = true;
            }
        }
    }

    private void FlipSprite()
    {
        if (_horizontalInput < 0) _facingRight = false;
        else if (_horizontalInput > 0) _facingRight = true;
        if (!_facingRight) SpriteRenderer.flipX = true;
        else SpriteRenderer.flipX = false;
    }
    //------------------------------------------------------------------------------------------------------------------

    private void ChangeAnimationState(string newAnimation)
    {
        if (_currentAnimaton == newAnimation) return;
        Animator.Play(newAnimation);
        _currentAnimaton = newAnimation;
    }
}