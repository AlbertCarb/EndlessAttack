﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
/**/
    /*
    Skeleton::Start() Skeleton::Start()

    NAME
        Skeleton::Start - initializes the Skeleton class objects

    SYNOPSIS
        protected override void Skeleton::Start(); 
        
    DESCRIPTION
        This function is responsible for acting as a constructor for the Skeleton
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it initalizes certain 
        Skeleton-specific stats and calls back the base class Start function.
        
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
        BaseAttackDamage = 10;
        Speed = 1.20f;
        m_initHealth = 20;
        m_health.Initialize(m_initHealth, m_initHealth);    
        base.Start(); 
    }
/* protected override void Skeleton::Start(); */

/**/
    /*
    Skeleton::Update() Skeleton::Update()

    NAME
        Skeleton::Update - updates the state of the Skeleton class objects 

    SYNOPSIS
        protected override void Skeleton::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the Skeleton class' objects by checking its current 
        state and values frame by frame. The values and states that are to be 
        tracked are specified in the body of the function. 

        This first makes the necessary updates for Skeleton-specific values
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
/* protected override void Skeleton::Update(); */
}
