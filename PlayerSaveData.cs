using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSaveData
{
    public float m_currHealth; // saves the current health value of the player
    public float m_maxHealth; // saves the maximum health value of the player 
    public float m_attackDamage; // saves the attack damage of the player 
    public float m_speed; // saves the movement speed of the player 

    // float array to save the x,y,z coordinates of the player's vector position 
    public float[] m_postion; 

/**/
    /*
    PlayerSaveData::PlayerSaveData() PlayerSaveData::PlayerSaveData()

    NAME
        PlayerSaveData::PlayerSaveData - initializes the PlayerSaveData class objects

    SYNOPSIS
        public PlayerSaveData::PlayerSaveData(Player a_player); 
            a_player -> the reference to the player being saved
       
    DESCRIPTION
        This function is responsible for acting as a constructor for the PlayerSaveData
        class objects. These variables will be referenced when saving the PlayerSaveData
        data to our save file.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/3/2019
    */
/**/   
    public PlayerSaveData(Player a_player)
    {
        m_currHealth = a_player.m_health.MyCurrentValue;
        m_maxHealth = a_player.BaseHealth;
        m_attackDamage = a_player.BaseAttackDamage;
        m_speed = a_player.Speed;
        
        m_postion = new float[3];
        m_postion[0] = a_player.transform.position.x;
        m_postion[1] = a_player.transform.position.y;
        m_postion[2] = a_player.transform.position.z;   
    }
/* public PlayerSaveData::PlayerSaveData(Player a_player); */
}
