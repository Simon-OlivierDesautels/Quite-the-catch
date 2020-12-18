using System.Collections.Generic;
using UnityEngine;

public class AnimationBlender : MonoBehaviour
{
    protected Human ParentClass;
    protected Animator Animator;
    protected RootBlender RootBlender;
    [SerializeField] protected List<AnimationClip> animationClips = new List<AnimationClip>();
    

    void Awake()
    {
        ParentClass = GetComponent<Human>();
        Animator = GetComponent<Animator>();
        RootBlender = GetComponent<RootBlender>();
    }


}
