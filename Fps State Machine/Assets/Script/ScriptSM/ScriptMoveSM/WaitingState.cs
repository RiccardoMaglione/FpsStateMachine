using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManagerMove.Setup();
        GameManagerMove.EventSetup();
        Debug.Log("Sono nella waiting state");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Input.GetKey(KeyCode.W) &! Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) &! Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.A) &! Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.D) &! Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("Sto per cambiare stato da wait a walk");
            GameManagerMove.WalkTriggerState();
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("Sto per cambiare stato da wait a run");
            GameManagerMove.RunTriggerState();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Sto per cambiare stato da wait a crunch");
            GameManagerMove.CrunchTriggerState();
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
