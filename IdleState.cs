using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{
    private Enemy m_parent; // reference to enemy

/**/
    /*
    IdleState::Enter() IdleState::Enter()

    NAME
        IdleState::Enter - sets reference to enemy and target to null

    SYNOPSIS
        public void IdleState::Enter(Enemy a_parent); 
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
        this.m_parent.Target = null; // sets our target to null since the enemy is no longer moving
    }
/* public void IdleState::Enter(Enemy a_parent); */

/**/
    /*
    IdleState::Exit() IdleState::Exit()

    NAME
        IdleState::Exit - preforms a function upon leaving this state

    SYNOPSIS
        public void IdleState::Exit(); 
        
    DESCRIPTION
        This function is not doing anything for this state but is necessary 
        to have to maintain the structure of the interface.

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
    }
/* public void IdleState::Exit(); */

/**/
    /*
    IdleState::Update() IdleState::Update()

    NAME
        IdleState::Update - updates the state of the IdleState class objects

    SYNOPSIS
        public void IdleState::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the IdleState class' objects by checking its current 
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
        if (m_parent.Target != null)
        {
            m_parent.ChangeState(new FollowState());
        }
    }
/* public void IdleState::Update(); */
}
