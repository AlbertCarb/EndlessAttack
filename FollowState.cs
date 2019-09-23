using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : IEnemyState
{
    private Enemy m_parent; // reference to enemy 

/**/
    /*
    FollowState::Enter() FollowState::Enter()

    NAME
        FollowState::Enter - sets reference to enemy

    SYNOPSIS
        public void FollowState::Enter(Enemy a_parent); 
            a_parent -> reference to the enemy
        
    DESCRIPTION
        This function is apart of the IEnemyState interface and this is one of
        its functions. This creates our reference to the active enemy object
        upon entering this state. 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/13/2019
    */
/**/
    public void Enter(Enemy a_parent)
    {
        this.m_parent = a_parent;
    }
/* public void FollowState::Enter(Enemy a_parent); */

/**/
    /*
    FollowState::Update() FollowState::Update()

    NAME
        FollowState::Update - updates the state of the FollowState class objects

    SYNOPSIS
        public void FollowState::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the FollowState class' objects by checking its current 
        state and values frame by frame. The values and states that are to be 
        tracked are specified in the body of the function. 
        
        Update is called once per frame.

        This will be used on the enemy so they can follow the player and is
        part of our IEnemyState interface.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/13/2019
    */
/**/
    public void Update()
    {
        // if the target isn't null
        // then move the enemy in the direction of the player
        if (m_parent.Target != null)
        {
            m_parent.Direction = (m_parent.Target.transform.position - m_parent.transform.position).normalized;
            m_parent.transform.position = Vector2.MoveTowards(m_parent.transform.position, m_parent.Target.position, m_parent.Speed * Time.deltaTime);
        }
        else // else change state to idle
        {
            m_parent.ChangeState(new IdleState());
        }
    }
/* public void FollowState::Update(); */

/**/
    /*
    FollowState::Exit() FollowState::Exit()

    NAME
        FollowState::Exit - preforms a function upon leaving this state

    SYNOPSIS
        public void FollowState::Exit(); 
        
    DESCRIPTION
        This function is responsible for halting the enemy's movement
        once the state has been exited. 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/13/2019
    */
/**/
    public void Exit()
    {
        m_parent.Direction = Vector2.zero;
    }
/* public void FollowState::Exit(); */
}
