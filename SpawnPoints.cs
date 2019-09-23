using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    private static SpawnPoints m_spawn; // class object for singleton reference 
    public Transform[] m_spawnPoints; // array to store all the spawn points

/**/
    /*
    SpawnPoints::Start() SpawnPoints::Start()

    NAME
        SpawnPoints::Start - initializes the SpawnPoints class objects

    SYNOPSIS
        void SpawnPoints::Start(); 
       
    DESCRIPTION
        This function is responsible for acting as a constructor for the SpawnPoints
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it initalizes certain 
        SpawnPoints-specific stats.
    
        Start is called before the first frame update.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/21/2019
    */
/**/
    void Start()
    {
        Spawn = this;
    }
/* void SpawnPoints::Start(); */

/**/
    /*
    SpawnPoints::Spawn SpawnPoints::Spawn

    NAME
        SpawnPoints::Spawn - gets/sets the class object m_spawn

    SYNOPSIS
        public static SpawnPoints SpawnPoints::Spawn; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_spawn

        This is a singleton object that will be used to manipulate values in this class within other classes

    RETURNS
        Class value of m_spawn

    AUTHOR
        Albert Carbillas

    DATE
        8/21/2019
    */
/**/
    public static SpawnPoints Spawn
    {
        get
        {
            return m_spawn;
        }

        set
        {
            m_spawn = value;
        }
    }
/* public static SpawnPoints SpawnPoints::Spawn; */
}
