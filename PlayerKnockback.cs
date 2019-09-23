using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    [SerializeField]
    private float knockbackForce; // the force in which the player is knocked back

    [SerializeField]
    private float knockbackDelay; // the delay between knockbacks

/**/
    /*
    PlayerKnockback::OnTriggerEnter2D() PlayerKnockback::OnTriggerEnter2D()

    NAME
        PlayerKnockback::OnTriggerEnter2D - triggers an action on collision

    SYNOPSIS
        private void PlayerKnockback::OnTriggerEnter2D(Collider2D a_other); 
            a_other -> the collider that is attached to another object

    DESCRIPTION
        This function is responsible for triggering a player knockback once the player's attack collider
        hits into the enemy's hitbox. Once this function is triggered, the enemy will be hit back

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
        if (a_other.tag == "Enemy")
        {
            Rigidbody2D enemy = a_other.GetComponent<Rigidbody2D>();

            if (enemy != null)
            {
                enemy.isKinematic = false;
                Vector2 positionDifference = enemy.transform.position - transform.position;
                positionDifference = positionDifference.normalized * knockbackForce; 
                enemy.AddForce(positionDifference, ForceMode2D.Impulse);
                StartCoroutine(KnockbackRoutine(enemy));
            }
        }
    }
/* private void PlayerKnockback::OnTriggerEnter2D(Collider2D a_other); */

/**/
    /*
    PlayerKnockback::KnockbackRoutine() PlayerKnockback::KnockbackRoutine()

    NAME
        PlayerKnockback::KnockbackRoutine - triggers an action on collision

    SYNOPSIS
        private IEnumerator PlayerKnockback::KnockbackRoutine(Rigidbody2D a_player); 
            a_enemy -> the rigidbody of the enemy

    DESCRIPTION
        This function is responsible for adding delay between knockbacks by running a coroutine after 
        the enemy is hit.

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
    private IEnumerator KnockbackRoutine(Rigidbody2D a_enemy)
    {
        // if the rigidbody has not been destroyed then start routine
        if (a_enemy != null) 
        {
            yield return new WaitForSeconds(knockbackDelay);
            a_enemy.velocity = Vector2.zero;
            a_enemy.isKinematic = true;
        }
    }
}
