using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveIconController : MonoBehaviour
{
    public GameObject saxaIcon;
    public GameObject diagonalaIcon;
    public GameObject stakaIcon;
    public GameObject sittingIcon;

    //private Animator saxaAnimator;
    private Animator diagonalaAnimator;
    private Animator stakaAnimator;
    private Animator sittingAnimator;

    private void Awake()
    {
        //saxaAnimator = saxaIcon.GetComponent<Animator>();
        diagonalaAnimator = diagonalaIcon.GetComponent<Animator>();
        stakaAnimator = stakaIcon.GetComponent<Animator>();
        sittingAnimator = sittingIcon.GetComponent<Animator>();
    }

    public void SetActiveIcon(int iconNumber)
    {
        //saxaAnimator.SetBool("InterruptBool", true);
        diagonalaAnimator.SetBool("InterruptBool", true);
        stakaAnimator.SetBool("InterruptBool", true);
        sittingAnimator.SetBool("InterruptBool", true);

        Animator targetAnimator = null;

        switch (iconNumber)
        {
            //case 1:
            //    targetAnimator = saxaAnimator;
            //    break;
            case 2:
                targetAnimator = diagonalaAnimator;
                break;
            case 3:
                targetAnimator = stakaAnimator;
                break;
            case 4:
                targetAnimator = sittingAnimator;
                break;
            default:
                break;
        }

        if (targetAnimator != null)
        {
            targetAnimator.SetBool("InterruptBool", false);
            targetAnimator.Play("Style Icon Animation");
        }

        return;
    }
}