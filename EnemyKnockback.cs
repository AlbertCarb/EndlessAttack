using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    [SerializeField]
    private float knockbackForce; // the force in which the player is knocked back

    [SerializeField]
    private float knockbackDelay; // the delay between knockbacks

/**/
    /*
    EnemyKnockback::OnTriggerEnter2D() EnemyKnockback::OnTriggerEnter2D()

    NAME
        EnemyKnockback::OnTriggerEnter2D - triggers an action on collision

    SYNOPSIS
        private void EnemyKnockback::OnTriggerEnter2D(Collider2D a_other); 
            a_other -> the collider that is attached to another object

    DESCRIPTION
        This function is responsible for triggering an enemy knockback once the enemy's attack collider
        hits into the player's hitbox. Once this function is triggered, the player will be hit back

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
        // if the object is the player then enable knockback 
        if (a_other.tag == "Player")
        {
            // references the player's rigidbody
            Rigidbody2D player = a_other.GetComponent<Rigidbody2D>();

            // if the playyer is not dead then apply an impulse force to push the player
            if (player != null)
            {
                Vector2 positionDifference = player.transform.position - transform.position;
                positionDifference = positionDifference.normalized * knockbackForce; 
                player.AddForce(positionDifference, ForceMode2D.Impulse);
                StartCoroutine(KnockbackRoutine(player));
            }
        }
    }
/* private void EnemyKnockback::OnTriggerEnter2D(Collider2D a_other); */

/**/
    /*
    EnemyKnockback::KnockbackRoutine() EnemyKnockback::KnockbackRoutine()

    NAME
        EnemyKnockback::KnockbackRoutine - triggers an action on collision

    SYNOPSIS
        private IEnumerator EnemyKnockback::KnockbackRoutine(Rigidbody2D a_player); 
            a_player -> the rigidbody of the player

    DESCRIPTION
        This function is responsible for adding delay between knockbacks by running a coroutine after 
        the player is hit.

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
    private IEnumerator KnockbackRoutine(Rigidbody2D a_player)
    {
        // if the rigidbody has not been destroyed then start routine
        if (a_player != null) 
        {
            yield return new WaitForSeconds(knockbackDelay);
            a_player.velocity = Vector2.zero;
        }
    }
/* private IEnumerator EnemyKnockback::KnockbackRoutine(Rigidbody2D a_player); */
}

