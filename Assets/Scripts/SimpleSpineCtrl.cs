using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class SimpleSpineCtrl : MonoBehaviour
{
    private SkeletonAnimation _skeletonAnimation;
    public string atkAnimationName = "atk";
    public string idleAnimationName = "idle";
    public string runAnimationName = "run";
    // Start is called before the first frame update
    void Start()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
    }

    public void Run()
    {
        PlayAnimation(runAnimationName);
    }
    
    public void Idle()
    {
        PlayAnimation(idleAnimationName);
    }
    
    public void Attack()
    {
        PlayAnimation(atkAnimationName);
    }
    
    public void PlayAnimation(string animationName)
    {
        _skeletonAnimation.AnimationName = animationName;
    }
}
