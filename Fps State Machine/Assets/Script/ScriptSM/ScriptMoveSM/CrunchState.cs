using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrunchState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Sono nel crunch state");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W) & !Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) & !Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.A) & !Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.D) & !Input.GetKey(KeyCode.LeftControl))
            {
                Debug.Log("Sto per cambiare stato da crunch a walk");
                GameManagerMove.WalkTriggerState();
            }
            else
            {
                Debug.Log("Sto per cambiare stato da crunch a wait");
                GameManagerMove.WaitingTriggerState();
            }
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
