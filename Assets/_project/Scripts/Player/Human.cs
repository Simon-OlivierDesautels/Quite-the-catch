using System;
using _project.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(FiniteStateMachine))]

public class Human : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;

    public enum PlayerFacing {Left, Right}

    public PlayerFacing CurrentDirection { get; set; }

    #region -Various states-

    public float PlayerAxis
    {
        get { return _playerAxis; }
        set { _playerAxis = value; }
    }

    public bool PlayerGrounded { get; set; }
    
    public bool PlayerJumping { get; set; }
    
    public bool CanJump{ get; set; }
    
    public bool PlayerRunning { get; set; }
    
    public bool PlayerFalling { get; set; }

    public bool FacingRight  { get; set; }
    public bool PlayerCatching  { get; set; }
    public float PlayerWidth  { get; private set; }

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
        CanJump = true;
        PlayerWidth = transform.localScale.x;
    }

    private void Update()
    {
        GravityScale();
    }

    private void GravityScale()
    {
        if (PlayerGrounded) PlayerFalling = false;
        if (PlayerFalling) Rigidbody2D.gravityScale = 12;
        else Rigidbody2D.gravityScale = 6;
    }

    public void AgainstWind()
    {
        switch (CurrentDirection)
        {
            case PlayerFacing.Left:
                if (_playerAxis > 0) _isAgainstWind = true;
                else if (_playerAxis < 0) _isAgainstWind = false;
                break;
            
            case PlayerFacing.Right:
                if (_playerAxis < 0) _isAgainstWind = true;
                else if (_playerAxis > 0) _isAgainstWind = false;
                break;
        }

        switch (_isAgainstWind)
        {
            case true :
                PlayerRunning = false;
                break;
            case false:
                PlayerRunning = true;
                break;
        }
    }

  

    #region -On input-
    private void OnMove(float movement)
    {
        _playerAxis = movement;
    }
    private void OnJump()
    {
        if (!CanJump) return;
        _playerMovement.VerticalMovement();
    }
    private void OnCatch()
    {
        switch (PlayerGrounded)
        {
            case true : PlayerCatching = true;
                break;
        }
        
    }
    #endregion
    
    #region -Enable/disable-
    
    private void OnEnable()
    {
        inputReader.JumpEvent += OnJump;
        inputReader.MoveEvent += OnMove;
        inputReader.CatchEvent += OnCatch;
    }
    private void OnDisable()
    {
        inputReader.JumpEvent -= OnJump;
        inputReader.MoveEvent -= OnMove;
        inputReader.CatchEvent -= OnCatch;
    }
    
    #endregion
}