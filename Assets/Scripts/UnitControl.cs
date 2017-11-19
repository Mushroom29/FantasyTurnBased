using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControl : MonoBehaviour
{
    public bool isActiveUnit = false;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isActiveUnit)
        {
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("UnitSeleted") == false)
            {
                animator.SetTrigger("UnitSelected");
            }
            //print(animator.GetCurrentAnimatorStateInfo(0).nameHash);
            //    AnimatorStateInfo.tagHash);
            //animator.SetTrigger("UnitSelected");
        }
        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("UnitUnselected") == false)
            {
                animator.SetTrigger("UnitUnselected");
            }
        }
    }
}