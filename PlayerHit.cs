using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
/**/
    /*
    PlayerHit::OnTriggerEnter2D() PlayerHit::OnTriggerEnter2D()

    NAME
        PlayerHit::OnTriggerEnter2D - triggers an action on collision

    SYNOPSIS
        private void PlayerHit::OnTriggerEnter2D(Collider2D a_other); 
            a_other -> the collider that is attached to another object

    DESCRIPTION
        This function is responsible for triggering a player hit once the players's attack collider
        hits into the enemy's hitbox. Once this function is triggered, the enemy will take damage
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
    private void OnTriggerEnter2D(Collider2D p_other)
    {
        // if the tag of the other object is player then damage it
        if (p_other.CompareTag("Enemy") && this.CompareTag("Sword"))
        {
            Enemy enemy; 
            enemy = p_other.gameObject.GetComponent<Enemy>();
            Debug.Log("enemy was hit" + gameObject.name, gameObject);
            enemy.TakeDamage(Player.Plyr.BaseAttackDamage);
        }
    }
/* private void PlayerHit::OnTriggerEnter2D(Collider2D a_other); */
}
