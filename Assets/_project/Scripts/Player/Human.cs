using System;
using _project.Scripts;
using UnityEngine;

public class Human : PlayerStateMachine
{
    [SerializeField] private InputReader _inputReader;

    #region -Various states-

    public float PlayerAxis
    {
        get { return _playerAxis; }
        set { _playerAxis = value; }
    }

    public bool PlayerGrounded { get; set; }
    
    public bool PlayerJumping { get; set; }
    
    public bool PlayerRunning { get; set; }
    
    public bool PlayerFalling { get; set; }

    public bool FacingRight  { get; set; }

    #endregion

    public Rigidbody2D Rigidbody2D { get; private set; }
    public Animator Animator { get; private set; }
    private PlayerMovement _playerMovement;

    private float _playerAxis;
    private bool _isWindChecked;
    private bool _isAgainstWind;


    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        GravityScale();
    }

    private void GravityScale()
    {
        if (PlayerGrounded) PlayerFalling = false;
        if (PlayerFalling) Rigidbody2D.gravityScale = 12;
        else Rigidbody2D.gravityScale = 4;
    }

    public void AgainstWind()
    {
        if (!FacingRight)
        {
            if (_playerAxis > 0) _isAgainstWind = true;
            else if (_playerAxis < 0) _isAgainstWind = false;

            if (_isAgainstWind) PlayerRunning = false;
            else if (!_isAgainstWind) PlayerRunning = true;
        }
        else
        {
            if (_playerAxis > 0) _isAgainstWind = true;
            else if (_playerAxis < 0) _isAgainstWind = false;

            if (_isAgainstWind) PlayerRunning = true;
            else if (!_isAgainstWind) PlayerRunning = false;
        }
    }

    private void OnMove(float movement)
    {
        _playerAxis = movement;
    }
    
    private void OnJump()
    {
        _playerMovement.VerticalMovement();
    }

    private void OnCatch()
    {
       
    }
    
    #region -Enable/disable-
    
    private void OnEnable()
    {
        _inputReader.JumpEvent += OnJump;
        _inputReader.MoveEvent += OnMove;
        _inputReader.CatchEvent += OnCatch;
    }
    private void OnDisable()
    {
        _inputReader.JumpEvent -= OnJump;
        _inputReader.MoveEvent -= OnMove;
        _inputReader.CatchEvent -= OnCatch;
    }
    
    #endregion
}