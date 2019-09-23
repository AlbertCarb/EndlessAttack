using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{    
    private Transform m_target; // reference to the player target 
    private IEnemyState m_currentState; // reference to the current state from the IEnemyState interface

    [SerializeField]
    private Pathfinding m_aStar; // reference to the pathfinding class for the A* algorithm (NOT USED FOR FINAL BUILD)
    
/**/
    /*
    Enemy::Awake() Enemy::Awake()

    NAME
        Enemy::Awake - initializes the state of the Enemy class objects 

    SYNOPSIS
        protected void Enemy::Awake(); 
        
    DESCRIPTION
        This function is responsible for intialzing varaibles or game states
        before the game starts. It is called after all objects are intialized. 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/25/2019
    */
/**/
    protected void Awake()
    {
        ChangeState(new IdleState());
    }
/* protected void Enemy::Awake(); */

/**/
    /*
    Enemy::Update() Enemy::Update()

    NAME
        Enemy::Update - updates the state of the Enemy class objects 

    SYNOPSIS
        protected override void Enemy::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the Enemy class' objects by checking its current 
        state and values frame by frame. The values and states that are to be 
        tracked are specified in the body of the function. 

        This first makes the necessary updates for enemy-specific values
        and then jumps back to the character class to perform general updates
        
        Update is called once per frame.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        2/20/2019
    */
/**/
    protected override void Update()
    {
        if (IsAlive)
        {
            m_currentState.Update();
        }

        // this allows us to jump back to the parent class 
        // and call their update actions afterwards
        base.Update();
    }
/* protected override void Enemy::Update(); */

/**/
    /*
    Enemy::IsDead Enemy::IsDead

    NAME
        Enemy::IsDead - gets the boolean value of IsDead

    SYNOPSIS
        public override bool Enemy::IsDead; 
        
    DESCRIPTION
        This accessor function is repsonsible for getting the current value of IsDead 
        to determine whether or not a enemy is currently dead. 

    RETURNS
        true -> if enemy is dead
        false -> if enemy is not dead

    AUTHOR
        Albert Carbillas

    DATE
        2/20/2019
    */
/**/
    public override bool IsDead
    {
        get
        {
            return m_health.MyCurrentValue <= 0;
        }
    }
/* public override bool Enemy::IsDead; */

/**/
    /*
    Enemy::Target Enemy::Target

    NAME
        Enemy::Target - gets/sets the current target

    SYNOPSIS
        public Transform Enemy::Target; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current target
        of the enemy based off of its current transformation in the world.

    RETURNS
        The transform or positional value of the target

    AUTHOR
        Albert Carbillas

    DATE
        2/22/2019
    */
/**/
    public Transform Target
    {
        get
        {
            return m_target;
        }

        set
        {
            m_target = value;
        }
    }
/* public Transform Enemy::Target; */

/**/
    /*
    Enemy::AStar Enemy::AStar

    NAME
        Enemy::AStar - gets/sets the current pathfinding reference

    SYNOPSIS
        public Pathfinding Enemy::AStar; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current 
        reference to the pathfinding script in order to find its target

    RETURNS
        Pathfinding object

    AUTHOR
        Albert Carbillas

    DATE
        8/25/2019
    */
/**/
    public Pathfinding AStar
    {
        // This pathfinding methodology was not used in the final build do to
        // complications with the world environment and the pathfinding algorithm 
        get
        {
            return m_aStar;
        }

        set
        {
            m_aStar = value;
        }
    }
/* public Pathfinding Enemy::AStar; */

/**/
    /*
    Enemy::ChangeState Enemy::ChangeState

    NAME
        Enemy::ChangeState - changes the state of the enemy

    SYNOPSIS
        public void ChangeState(IEnemyState a_newState); 
            a_newState -> stores the current state of the enemy
        
    DESCRIPTION
        This function is responsible for changing the current state of the enemy
        based on the associated Enemy State interface. 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/25/2019
    */
/**/
    public void ChangeState(IEnemyState a_newState)
    {
        if (m_currentState != null)
        {
            m_currentState.Exit();
        }

        m_currentState = a_newState;
        m_currentState.Enter(this);
    }
/* public void Enemy::ChangeStar(IEnemyState a_newState); */

/**/
    /*
    Enemy::TakeDamage() Enemy::TakeDamage()
    NAME
        Enemy::TakeDamage - inflicts damage onto the enemy

    SYNOPSIS
        public override void TakeDamage(float a_damage); 
            a_damage -> the float value of the damage a character takes
        
    DESCRIPTION
        This function is reponsible for applying damage to a enemy
        after they have been attacked. The value of the damage parameter is subtracted 
        from the current value of the character's health. If their health reaches 0
        then their state is changed to "die". 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        2/20/2019
    */
/**/
    public override void TakeDamage(float a_damage)
    {
        // just directly calls the base class function 
        base.TakeDamage(a_damage);
    }
/* public override void Enemy::TakeDamage(float a_damage); */
}