﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Sono in Walk State");
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("Sto Camminando nel walk state");
            GameManagerMove.RunTriggerState();
        }
        else
        {
            Debug.Log("Sono stanco e mi fermo");
            GameManagerMove.WaitingTriggerState();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
