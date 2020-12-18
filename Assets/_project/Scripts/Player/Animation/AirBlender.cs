using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class AirBlender : AnimationBlender
{
    private Dictionary<AnimationClip, string> _animations = new Dictionary<AnimationClip, string>();

    private void Start()
    {
        foreach (var animation in animationClips)
        {
            _animations.Add(animation, animation.name);
        }
    }

    private void Update()
    {
        VerticalMovementAnimation();
        ParentClass.AgainstWind();
    }

    private void VerticalMovementAnimation()
    {
        Catch();
        if (ParentClass.PlayerCatching) return;
        Jump();
        Land();
    }

    private void Jump()
    {
        if (!(ParentClass.Rigidbody2D.velocity.y > 0)) return;
        PlayAnimation(MethodBase.GetCurrentMethod().Name);
        ParentClass.PlayerRunning = true;
    }

    private void Land()
    {
        if (!(ParentClass.Rigidbody2D.velocity.y < 0)) return;
        PlayAnimation(MethodBase.GetCurrentMethod().Name);
        ParentClass.PlayerRunning = true;
        ParentClass.PlayerFalling = true;
    }
    
    private void Catch()
    {
        if (!ParentClass.PlayerCatching) return;
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

    private void OnDisable()
    {
        if (ParentClass.PlayerCatching)
        {
            RootBlender.EndOfTrigger = false;
            ParentClass.PlayerCatching = false;
        }
    }
}