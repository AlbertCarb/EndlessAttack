using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehaviour : StateMachineBehaviour
{
    private float m_timePastDeath; // stores the amount of time after a character has died

/**/
    /*
    DeathBehaviour::OnStateEnter() DeathBehaviour::OnStateEnter()

    NAME
        DeathBehaviour::OnStateEnter - destroys character after death

    SYNOPSIS
        override public void DeathBehaviour::OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex); 
            animator -> reference to the character's animator
            stateInfo -> reference to the animator's current state
            layerIndex -> reference to the index in which the particular animation lies
       
    DESCRIPTION
        This function is responsible for destroying the character's transform after entering
        the death state.
    
        OnStateEnter is called when a transition starts and the state machine starts to evaluate this state

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        7/11/2019
    */
/**/
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.transform.GetChild(0).gameObject);        
    }
/* override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex); */

/**/
    /*
    DeathBehaviour::OnStateUpdate() DeathBehaviour::OnStateUpdate()

    NAME
        DeathBehaviour::OnStateUpdate - destroys character's object after death

    SYNOPSIS
        override public void DeathBehaviour::OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex); 
            animator -> reference to the character's animator
            stateInfo -> reference to the animator's current state
            layerIndex -> reference to the index in which the particular animation lies
       
    DESCRIPTION
        This function is responsible for destroying the character object after entering
        the death state.
    
        OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    
    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        7/11/2019
    */
/**/
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_timePastDeath += Time.deltaTime;

        // if more than 1 second has passed then destroy the character's object from the game
        if (m_timePastDeath >= 1)
        {
            Destroy(animator.gameObject);
        } 
    }
/* override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex); */
}
