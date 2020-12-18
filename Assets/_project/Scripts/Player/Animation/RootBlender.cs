using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootBlender : MonoBehaviour
{
    private Human _parentClass;
    private GroundBlender _groundBlender;
    private AirBlender _airBlender;
    private Animator _animator;
    private string _currentAnimaton;
    public bool EndOfTrigger { get; set; }


    private void Awake()
    {
        _parentClass = GetComponent<Human>();
        _animator = GetComponent<Animator>();
        _groundBlender = GetComponent<GroundBlender>();
        _airBlender = GetComponent<AirBlender>();

    }

    private void Update()
    {
        ReturnKeyBlender();
    }

    private void ReturnKeyBlender()
    {
        switch (_parentClass.PlayerGrounded)
        {
            case false:
                _groundBlender.enabled = false;
                _airBlender.enabled = true;
                break;
            case true:
                _airBlender.enabled = false;
                _groundBlender.enabled = true;
                break;
        }
    }
    
    public void ChangeAnimationState(string newAnimation)
    {
        if (_currentAnimaton == newAnimation) return;
        _animator.Play(newAnimation);
        _currentAnimaton = newAnimation;
    }
  
}