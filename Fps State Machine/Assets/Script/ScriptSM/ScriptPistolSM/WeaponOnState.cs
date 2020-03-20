using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOnState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManagerPistol.Setup();
        GameManagerPistol.EventSetup();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Sto per sparare");
            GameManagerPistol.ShotBullet();
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Devo ricaricare");
            GameManagerPistol.ReloadPistol();
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Metto via l'arma");
            GameManagerPistol.WeaponPistolOff();
        }
        else if (Input.GetMouseButton(1))
        {
            Debug.Log("Ti miro");
            GameManagerPistol.FocusPistol();
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
