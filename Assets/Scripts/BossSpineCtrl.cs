using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class BossSpineCtrl : MonoBehaviour
{
    private SkeletonAnimation _skeletonAnimation;
    public string idleAnimationName = "idle";
    public string runAnimationName = "run";
    
    public string jumpStart="atk1_start";
    public string jumpEnd="atk1_end";
    public string atk2="atk2";
    public string atk4="atk4"; 
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
    
    public void JumpStart()
    {
        PlayAnimation(jumpStart);
    }
    
    public void JumpEnd()
    {
        PlayAnimation(jumpEnd);
    }
    
    public void Attack2()
    {
        PlayAnimation(atk2);
    }

    public void Attack4()
    {
        PlayAnimation(atk4);
    }
    
    public void PlayAnimation(string animationName)
    {
        _skeletonAnimation.AnimationName = animationName;
    }
}