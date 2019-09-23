using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    private Enemy m_parent; // reference to the enemy
    private Collider2D currentCollider; // reference to the circle collider

/**/
    /*
    Range::Start() Range::Start()

    NAME
        Range::Start - initializes the Range class objects

    SYNOPSIS
        private void Range::Start(); 
       
    DESCRIPTION
        This function is responsible for acting as a constructor for the Range
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it initalizes certain 
        Range-specific stats.
    
        Start is called before the first frame update.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        6/20/2019
    */
/**/
    private void Start()
    {
        m_parent = GetComponentInParent<Enemy>();
    }
/* private void Range::Start(); */

/**/
    /*
    Range::OnTriggerEnter2D() Range::OnTriggerEnter2D()

    NAME
        Range::OnTriggerEnter2D - triggers an action on collision

    SYNOPSIS
        private void Range::OnTriggerEnter2D(Collider2D a_other); 
            a_other -> the collider that is attached to another object

    DESCRIPTION
        This function is responsible for triggering an enemy to follow the player one they have 
        entered their space. 

        OnTriggerEnter is a Unity-specific function that performs an action once a certain 
        collider or object has been triggered in game

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        6/20/2019
    */
/**/
    private void OnTriggerEnter2D(Collider2D a_other)
    {
        // if the object that collided is player, then 
        // set target 
        if (a_other.tag == "Player")
        {
            this.currentCollider = a_other;
            m_parent.Target = a_other.transform;
        }
    }
/* private void Range::OnTriggerEnter2D(Collider2D a_other); */

/**/
    /*
    Range::OnTriggerExit2D() Range::OnTriggerExit2D()

    NAME
        Range::OnTriggerExit2D - triggers an action on collision

    SYNOPSIS
        private void Range::OnTriggerExit2D(Collider2D a_other); 
            a_other -> the collider that is attached to another object

    DESCRIPTION
        This function is responsible for triggering an enemy to follow the player one they have 
        entered their space. 

        OnTriggerExit2D is a Unity-specific function that exits an action once a certain 
        collider or object has exited the trigger.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        6/20/2019
    */
/**/
    private void OnTriggerExit2D(Collider2D a_other)
    {
        // if the tag of the other object is Player and the collider
        // has already been triggered, then set current collider and
        // enemy's target to null
        if (a_other.tag == "Player" && this.currentCollider == a_other)
        {
            this.currentCollider = null;
            m_parent.Target = null;
        }
    }
/* private void Range::OnTriggerExit2D(Collider2D a_other); */
}
