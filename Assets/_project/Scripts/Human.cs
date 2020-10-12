using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
//    public string PlayerControls => _controlHorizontal; could be private or deleted
    public float PlayerAxis => _playerAxis;

    public bool Running
    {
        set => _isRunning = value;
    }


    [Header("Controls info")] [SerializeField]
    private PlayerNumber _playerNumber;

    [Header("Running")] [SerializeField] int _speed;

    [Header("Jumping")] [SerializeField] [Range(0, 10)]
    int _jumpForce;

    [SerializeField] private LayerMask _groundMask;

    [Header("Debug")] [SerializeField] private bool _debug;
    [SerializeField] private float _gizmosLength;
    [SerializeField] private Vector3 colliderOffset;

    private enum PlayerNumber
    {
        Player1,
        Player2
    };

    private Rigidbody2D Rigidbody2D;
    private string _controlHorizontal;
    private float _playerAxis;
    private bool _isGrounded;
    private bool _isRunning;

    protected virtual void Awake()
    {
        switch (_playerNumber)
        {
            case PlayerNumber.Player1:
                _controlHorizontal = "Horizontal.0";
                break;

            case PlayerNumber.Player2:
                _controlHorizontal = "Horizontal.1";
                break;
        }

        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected void HorizontalMovement()
    {
        if (_isRunning) _speed = 7;
        else _speed = 3;
        _playerAxis = Input.GetAxis(_controlHorizontal);
        float _deltaX = Input.GetAxis(_controlHorizontal) * _speed;
        Vector2 playerVelocity = new Vector2(_deltaX, Rigidbody2D.velocity.y);
        Rigidbody2D.velocity = playerVelocity;
    }

    protected void VerticalMovement()
    {
        GroundCollisionDetection();
        if (_isGrounded) Rigidbody2D.AddForce(Vector2.up * (_jumpForce * 2), ForceMode2D.Impulse);
    }

    protected void GroundCollisionDetection()
    {
        _isGrounded = Physics2D.Raycast(transform.position + colliderOffset, Vector3.down, _gizmosLength, _groundMask);
    }

    private void OnDrawGizmos()
    {
        if (_debug)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + colliderOffset,
                transform.position + colliderOffset + (Vector3.down * _gizmosLength));
        }
    }
}