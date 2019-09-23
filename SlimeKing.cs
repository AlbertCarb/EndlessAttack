using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeKing : Enemy
{
/**/
    /*
    SlimeKing::Start() SlimeKing::Start()

    NAME
        SlimeKing::Start - initializes the SlimeKing class objects

    SYNOPSIS
        protected override void SlimeKing::Start(); 
        
    DESCRIPTION
        This function is responsible for acting as a constructor for the SlimeKing
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it initalizes certain 
        SlimeKing-specific stats and calls back the base class Start function.
        
        Start is called before the first frame update.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        6/10/2019
    */
/**/
    protected override void Start()
    {
        BaseAttackDamage = 7;
        Speed = .75f;
        m_initHealth = 30;
        m_health.Initialize(m_initHealth, m_initHealth);
        base.Start(); 
    }
/* protected override void SlimeKing::Start(); */

/**/
    /*
    SlimeKing::Update() SlimeKing::Update()

    NAME
        SlimeKing::Update - updates the state of the SlimeKing class objects 

    SYNOPSIS
        protected override void SlimeKing::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the SlimeKing class' objects by checking its current 
        state and values frame by frame. The values and states that are to be 
        tracked are specified in the body of the function. 

        This first makes the necessary updates for SlimeKing-specific values
        and then jumps back to the enemy class to perform general updates
        
        Update is called once per frame.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        6/10/2019
    */
/**/
    protected override void Update()
    {
        base.Update(); 
    }
/* protected override void SlimeKing::Update(); */
}
