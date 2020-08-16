using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMethods : MonoBehaviour
{
    public void StartAnimationIfNotPlaying(Animator animator, string animationName)
    {
        if(AnimatorIsPlaying(animator))
        {
            animator.SetTrigger("InterruptTrigger");
        }
        animator.Play(animationName);
    }

    private bool AnimatorIsPlaying(Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).length >
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
