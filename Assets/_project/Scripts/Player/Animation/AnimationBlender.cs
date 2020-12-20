using System.Collections.Generic;
using UnityEngine;

namespace _project.Scripts.Player.Animation
{
    public class AnimationBlender : MonoBehaviour
    {
        protected Human ParentClass;
        protected Animator Animator;
        protected RootBlender RootBlender;
        protected Dictionary<AnimationClip, string> _animations = new Dictionary<AnimationClip, string>();
        protected bool FlowPending;
        
        void Awake()
        {
            ParentClass = GetComponent<Human>();
            Animator = GetComponent<Animator>();
            RootBlender = GetComponent<RootBlender>();
        }
    }
}
