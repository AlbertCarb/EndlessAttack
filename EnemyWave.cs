using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public Enemy[] m_enemyList; // array of the list of enemy types

    private static EnemyWave m_eWave; // class object for singleton 
    private Enemy m_type; // the type of enemy
    private int m_enemyCount; // the count of the enemies for the given wave

    void Start()
    {
        EWave = this;
    }

/**/
    /*
    EnemyWave::EWave EnemyWave::EWave

    NAME
        EnemyWave::EWave - gets/sets the boolean value of EnemyHealth

    SYNOPSIS
        public static EnemyWave::EWave; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_eWave

        This is a singleton object that will be used to manipulate values in this class within other classes

    RETURNS
        Class value of m_eWave

    AUTHOR
        Albert Carbillas

    DATE
        8/28/2019
    */
/**/
    public static EnemyWave EWave
    {
        get
        {
            return m_eWave;
        }

        set
        {
            m_eWave = value;
        }
    }
/* public static EnemyWave::EWave; */

/**/
    /*
    EnemyWave::Type EnemyWave::Type

    NAME
        EnemyWave::Type - gets/sets the boolean value of EnemyHealth

    SYNOPSIS
        public Enemy EnemyWave::Type; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_type

    RETURNS
        Enemy value of m_type

    AUTHOR
        Albert Carbillas

    DATE
        8/28/2019
    */
/**/
    public Enemy Type
    {
        get
        {
            return m_type;
        }

        set
        {
            m_type = value;
        }
    }
/* public Enemy EnemyWave::EWave; */

/**/
    /*
    EnemyWave::EnemyCount EnemyWave::EnemyCount

    NAME
        EnemyWave::EnemyCount - gets/sets the boolean value of EnemyHealth

    SYNOPSIS
        public int EnemyWave::EnemyCount; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_enemyCount

    RETURNS
        Enemy value of m_enemyCount

    AUTHOR
        Albert Carbillas

    DATE
        8/28/2019
    */
/**/
    public int EnemyCount
    {
        get
        {
            return m_enemyCount;
        }

        set
        {
            m_enemyCount = value;
        }
    }
/* public int EnemyWave::EnemyCount; */
}
