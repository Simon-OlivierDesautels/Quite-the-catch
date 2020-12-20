using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace _project.Scripts.Player.Animation
{
    public class GroundBlender : AnimationBlender
    {
        [SerializeField] private float _runningSpeed;
        [SerializeField] private List<AnimationClip> animationClips = new List<AnimationClip>();
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
            if (ParentClass.PlayerAxis == 0f && ParentClass) Idle();
      
        }

        private void Idle()
        {
            if(FlowPending) return;
            PlayAnimation(MethodBase.GetCurrentMethod().Name);
            ParentClass.PlayerRunning = false;
        }

        private void Walk(float horizontalInput)
        {
            if(FlowPending) return;
            if (horizontalInput < -_runningSpeed || horizontalInput > _runningSpeed) return;
            if (Math.Abs(horizontalInput) > 0)
            {
                PlayAnimation(MethodBase.GetCurrentMethod().Name);
                ParentClass.PlayerRunning = false;
            }
        }

        private void Run(float horizontalInput)
        {
            if(FlowPending) return;
            if (!(horizontalInput < -_runningSpeed) && !(horizontalInput > _runningSpeed)) return;
            PlayAnimation(MethodBase.GetCurrentMethod().Name);
            ParentClass.PlayerRunning = true;
        }

        private void Catch()
        {
            ParentClass.AgainstWind();
            PlayAnimation(MethodBase.GetCurrentMethod().Name);
            StartCoroutine(StopCatching());
        }

        IEnumerator StopCatching()
        {
            FlowPending = true;
            yield return new WaitForSeconds(0.00000000001f);
            float delay = Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(delay);
            FlowPending = false;
        }

        private void PlayAnimation(string methodName)
        {
            RootBlender.ChangeAnimationState(DictionaryTraductor(methodName));
        }

        private string DictionaryTraductor(string animationClip)
        {
            return _animations.Single(pair => pair.Value == animationClip).Value;
        }

        private void SwitchDirection(float horizontalInput)
        {
            Vector3 localScale = transform.localScale;
        
            if (horizontalInput > 0) ParentClass.FacingRight = true;
            else if (horizontalInput < 0) ParentClass.FacingRight = false;
        
            if (!ParentClass.FacingRight) transform.localScale = new Vector3(-_playerWidth, transform.localScale.y, localScale.z);
            else transform.localScale = new Vector3(_playerWidth, transform.localScale.y, localScale.z);

            Debug.Log(horizontalInput);
        }


    }
}