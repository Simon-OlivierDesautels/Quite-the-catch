using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Human ParentClass;
    [SerializeField] [Range(0, 10)] int _walkSpeed;
    [SerializeField] [Range(0, 10)] int _runSpeed;
    [SerializeField] [Range(0, 20)] int _jumpForce;

    private int _movementSpeed;

    private void Start()
    {
        ParentClass = GetComponent<Human>();
    }

    private void HorizontalMovement()
    {
        Vector2 playerVelocity =
            new Vector2(ParentClass.PlayerAxis * _movementSpeed, ParentClass.Rigidbody2D.velocity.y);
        ParentClass.Rigidbody2D.velocity = playerVelocity;
    }

    public void VerticalMovement()
    {
        if (!ParentClass.PlayerGrounded) return;
        ParentClass.Rigidbody2D.AddForce(Vector2.up * (_jumpForce * 2), ForceMode2D.Impulse);
        ParentClass.PlayerJumping = false;
    }

    private void Update()
    {
        SpeedCalculations();
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
    }

    private void SpeedCalculations()
    {
        if (ParentClass.PlayerRunning) _movementSpeed = _runSpeed;
        else _movementSpeed = _walkSpeed;
    }
}