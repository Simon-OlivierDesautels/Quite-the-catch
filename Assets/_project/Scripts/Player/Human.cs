using System;
using UnityEngine;

public class Human : MonoBehaviour
{
    public float PlayerAxis
    {
        get { return _playerAxis; }
        set { _playerAxis = value; }
    }
    public bool PlayerGrounded { get; set; }
    public bool PlayerJumping { get; set; }
    public bool PlayerRunning { get; set; }
    public bool PlayerFalling { get; set; }
    public bool FacingRight;

    public bool PlayerCatching;
    public Rigidbody2D Rigidbody2D { get; private set; }

    private float _playerAxis;
    private bool _isWindChecked;
    private bool _isAgainstWind;


    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
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
            else if(!_isAgainstWind) PlayerRunning = true;
        }
        else
        {
            if (_playerAxis > 0) _isAgainstWind = true;
            else if (_playerAxis < 0) _isAgainstWind = false;
            
            if (_isAgainstWind) PlayerRunning = true;
            else if(!_isAgainstWind) PlayerRunning = false;
        }
    }
}