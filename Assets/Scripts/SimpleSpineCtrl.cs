using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class SimpleSpineCtrl : MonoBehaviour
{
    private SkeletonAnimation _skeletonAnimation;
    public string atkAnimationName = "atk";
    public string jumpAtkAnimationName = "atk_move";
    public string idleAnimationName = "idle";
    public string runAnimationName = "run";
    
    public string jumpStart="atk1_start";
    public string jumpEnd="atk1_end";
    public string atk2="atk2";
    public string atk3="atk4"; 
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
    
    public void JumpAttack()
    {
        PlayAnimation(jumpAtkAnimationName);
    }
    
    public void PlayAnimation(string animationName)
    {
        _skeletonAnimation.AnimationName = animationName;
    }
}
