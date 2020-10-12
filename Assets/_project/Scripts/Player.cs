using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Human
{
    private bool isJumping;
    private void Update()
    {
        if (Input.GetButtonDown("Fire2")) isJumping = true;
    }

    void FixedUpdate()
    {
        HorizontalMovement();
        if (isJumping) VerticalMovement(); isJumping = false;
    }
    
}