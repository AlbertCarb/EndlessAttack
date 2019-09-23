using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
/**/
    /*
    EnemyHit::OnTriggerEnter2D() EnemyHit::OnTriggerEnter2D()

    NAME
        EnemyHit::OnTriggerEnter2D - triggers an action on collision

    SYNOPSIS
        private void EnemyHit::OnTriggerEnter2D(Collider2D a_other); 
            a_other -> the collider that is attached to another object

    DESCRIPTION
        This function is responsible for triggering an enemy hit once the enemy's attack collider
        hits into the player's hitbox. Once this function is triggered, the player will take damage
        relative to the attack damage for the specific type of enemy.

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
        // if the tag of the other object is player then damage it
        if (a_other.CompareTag("Player"))
        {
            Player player;
            player = a_other.gameObject.GetComponent<Player>();
            player.TakeDamage(this.GetComponentInParent<Enemy>().BaseAttackDamage);
        }
    }
/* private void EnemyHit::OnTriggerEnter2D(Collider2D a_other); */
}
