using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
/**/
    /*
    Slime::Start() Slime::Start()

    NAME
        Slime::Start - initializes the Slime class objects

    SYNOPSIS
        protected override void Slime::Start(); 
        
    DESCRIPTION
        This function is responsible for acting as a constructor for the Slime
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it initalizes certain 
        Slime-specific stats and calls back the base class Start function.
        
        Start is called before the first frame update.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        5/18/2019
    */
/**/
    protected override void Start()
    {
        BaseAttackDamage = 2;
        Speed = 1f;
        m_initHealth = 10;
        m_health.Initialize(m_initHealth, m_initHealth);
        base.Start(); 
    }
/* protected override void Slime::Start(); */

/**/
    /*
    Slime::Update() Slime::Update()

    NAME
        Slime::Update - updates the state of the Slime class objects 

    SYNOPSIS
        protected override void Slime::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the Slime class' objects by checking its current 
        state and values frame by frame. The values and states that are to be 
        tracked are specified in the body of the function. 

        This first makes the necessary updates for Slime-specific values
        and then jumps back to the enemy class to perform general updates
        
        Update is called once per frame.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        5/18/2019
    */
/**/
    protected override void Update()
    {
        base.Update(); 
    }
/* protected override void Slime::Update(); */
}
