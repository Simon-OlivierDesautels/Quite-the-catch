using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class GroundBlender : AnimationBlender
{
    [SerializeField] private float _runningSpeed;
    Dictionary<AnimationClip, string> _animations = new Dictionary<AnimationClip, string>();
    private float _horizontalInput;
    private float _playerWidth;
    private bool _facingRight;

    private void Start()
    {
        _playerWidth = transform.localScale.x;
        foreach (var animationClip in animationClips)
        {
            _animations.Add(animationClip, animationClip.name);
        }
    }

    private void Update()
    {
        HorizontalMovementAnimation();
    }

    private void HorizontalMovementAnimation()
    {
        _horizontalInput = ParentClass.PlayerAxis;
        SwitchDirection();
        Catch();
        if (ParentClass.PlayerCatching) return;
        Idle();
        Walk();
        Run();
    }

    private void Idle()
    {
        if (Math.Abs(_horizontalInput) > 0f) return;
        PlayAnimation(MethodBase.GetCurrentMethod().Name);
        ParentClass.PlayerRunning = false;
    }

    private void Walk()
    {
        if (_horizontalInput < -_runningSpeed || _horizontalInput > _runningSpeed) return;
        if (Math.Abs(_horizontalInput) > 0)
        {
            PlayAnimation(MethodBase.GetCurrentMethod().Name);
            ParentClass.PlayerRunning = false;
        }
    }

    private void Run()
    {
        if (!(_horizontalInput < -_runningSpeed) && !(_horizontalInput > _runningSpeed)) return;
        PlayAnimation(MethodBase.GetCurrentMethod().Name);
        ParentClass.PlayerRunning = true;
    }

    private void Catch()
    {
        if (!ParentClass.PlayerCatching) return;
        ParentClass.AgainstWind();
        PlayAnimation(MethodBase.GetCurrentMethod().Name);
        if (!RootBlender.EndOfTrigger) StartCoroutine(StopCatching());
    }

    IEnumerator StopCatching()
    {
        RootBlender.EndOfTrigger = true;
        yield return new WaitForSeconds(0.00001f);
        float delay = Animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(delay);
        RootBlender.EndOfTrigger = false;
        ParentClass.PlayerCatching = false;
    }

    private void PlayAnimation(string methodName)
    {
        RootBlender.ChangeAnimationState(DictionaryTraductor(methodName));
    }

    private string DictionaryTraductor(string animation)
    {
        return _animations.Single(pair => pair.Value == animation).Value;
    }
    private void SwitchDirection()
    {
        if(ParentClass.PlayerCatching) return;
     
        if (_horizontalInput > 0) ParentClass.FacingRight = true;
        else if (_horizontalInput < 0) ParentClass.FacingRight = false;
        if (!ParentClass.FacingRight)
            transform.localScale = new Vector3(-_playerWidth, transform.localScale.y, transform.localScale.z);
        else transform.localScale = new Vector3(_playerWidth, transform.localScale.y, transform.localScale.z);
    }
    
    
}