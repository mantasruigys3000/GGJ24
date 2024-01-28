using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public Animator animator;

    public void somethingElse()
    {
        animator.SetTrigger("dead");
        Debug.Log("mass");
    }
}
