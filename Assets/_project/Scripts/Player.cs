using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Human
{
    void FixedUpdate()
    {
        HorizontalMovement();
        VerticalMovement();
    }
    
}