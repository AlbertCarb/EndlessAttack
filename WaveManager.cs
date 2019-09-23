using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // enum to identify the different stages of the Wave
    public enum WaveState 
    { 
        SPAWNING, 
        WAITING, 
        COUNTING
    }

    public EnemyWave[] m_waves; // array of enemy waves

    private static WaveManager m_wManager; // class object for singleton
    private int m_waveIndex = 0; // current wave index in array 
    private float m_waveDelay = 10.0f; // delay between wave spawns
    private float m_initWaveDelay; // the initial delay when a round/game starts
    private WaveState m_currentState = WaveState.COUNTING; // the current state of the wave

/**/
    /*
    WaveManager::Start() WaveManager::Start()

    NAME
        WaveManager::Start - initializes the WaveManager class objects

    SYNOPSIS
        void WaveManager::Start(); 
       
    DESCRIPTION
        This function is responsible for acting as a constructor for the WaveManager
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it initalizes certain 
        WaveManager-specific stats.
    
        Start is called before the first frame update.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/20/2019
    */
/**/
    void Start()
    {
        WManager = this;
        m_initWaveDelay = m_waveDelay;
    }
/* void WaveManager::Start(); */

/**/
    /*
    WaveManager::Update() WaveManager::Update()

    NAME
        WaveManager::Update - updates the state of the WaveManager class objects

    SYNOPSIS
        void WaveManager::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the WaveManager class' objects by checking its current 
        state and values frame by frame. The values and states that are to be 
        tracked are specified in the body of the function. 
        
        Update is called once per frame.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/20/2019
    */
/**/
    void Update()
    {
        // if the wave is currently waiting state then 
        // check the current count of enemies on screen
        // if it is 0 then start the next wave otherwise wait
        if (m_currentState == WaveState.WAITING)
        {
            if (CheckEnemyCount(m_waves[WaveIndex]) == 0)
            {
                NextWave();
            } 
            else 
            {
                return;
            }
        }

        // if the intial wave delay has hit 0 then start spawning a new wave
        if (m_initWaveDelay <= 0)
        {
            if (m_currentState != WaveState.SPAWNING)
            {
                StartCoroutine(SpawnRoutine(m_waves[WaveIndex]));
            }
        }
        else // else start counting down the wave delay in the meantime
        {
            m_initWaveDelay -= Time.deltaTime;
        }
    }
/* void WaveManager::Update(); */

/**/
    /*
    WaveManager::WManager WaveManager::WManager

    NAME
        WaveManager::WManager - gets/sets the class object m_wManager

    SYNOPSIS
        public static WaveManager WaveManager::WManager; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_wManager

        This is a singleton object that will be used to manipulate values in this class within other classes

    RETURNS
        Class value of m_wManager

    AUTHOR
        Albert Carbillas

    DATE
        8/20/2019
    */
/**/
    public static WaveManager WManager
    {
        get
        {
            return m_wManager;
        }

        set
        {
            m_wManager = value;
        }
    }
/* public static WaveManager WManager; */

/**/
    /*
    WaveManager::WaveIndex WaveManager::WaveIndex

    NAME
        WaveManager::WaveIndex - gets/sets the int value of WaveIndex

    SYNOPSIS
        public int WaveManager::WaveIndex; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_waveIndex

    RETURNS
        int value of m_waveIndex

    AUTHOR
        Albert Carbillas

    DATE
        8/20/2019
    */
/**/
    public int WaveIndex
    {
        get
        {
            return m_waveIndex;
        }

        set
        {
            m_waveIndex = value;
        }
    }
/* public int WaveManager WaveIndex; */

/**/
    /*
    WaveManager::SpawnRoutine WaveManager::SpawnRoutine

    NAME
        WaveManager::SpawnRoutine - spawns enemies

    SYNOPSIS
        IEnumerator WaveManager::SpawnRoutine(EnemyWave a_wave); 
            a_wave -> references the type of wave to be spawned
        
    DESCRIPTION
        This function is responsible for performing the spawning of each wave.

    RETURNS
        IEnumerator

    AUTHOR
        Albert Carbillas

    DATE
        8/20/2019
    */
/**/
    private IEnumerator SpawnRoutine(EnemyWave a_wave)
    {
        // switch to spawning state
        m_currentState = WaveState.SPAWNING;

        // find and set the appropriate type of enemy and the amount of them
        EnemyWave.EWave.Type = SetEnemyType(a_wave);
        EnemyWave.EWave.EnemyCount = SetEnemyCount(a_wave);

        // for the size of count, spawn that amount of enemies of the specified type
        for (int i = 0; i < a_wave.EnemyCount; i++)
        {
            Spawn(a_wave.Type);
        }

        // after all enemies have been spawn then wait
        m_currentState = WaveState.WAITING;

        yield break;
    }
/* private IEnumerator SpawnRoutine(EnemyWave a_wave); */

/**/
    /*
    WaveManager::Spawn WaveManager::Spawn

    NAME
        WaveManager::Spawn - spawns enemies

    SYNOPSIS
        public void WaveManager::Spawn(Enemy a_enemy); 
            a_enemy -> references the type of enemy to be spawned
        
    DESCRIPTION
        This function is responsible for performing the spawning of the actual 
        enemies of the specified wave type and placing them randomly on the map.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/20/2019
    */
/**/
    private void Spawn(Enemy a_enemy)
    {
        Transform spawnPoint;

        // if the round is a boss level then spawn them in the middle of the arena
        if (WaveIndex == 9
        || WaveIndex == 19
        || WaveIndex == 29)
        {
            // middle is the first spawn point in the spawn array
            spawnPoint = SpawnPoints.Spawn.m_spawnPoints[0];
        }
        else // else pick them at random 
        {
            spawnPoint = SpawnPoints.Spawn.m_spawnPoints[Random.Range(0, SpawnPoints.Spawn.m_spawnPoints.Length)];
        }
        
        // sets the enemy's transformations relative to the world 
        Instantiate(a_enemy.transform, spawnPoint.position, spawnPoint.rotation);
    }
/* private void Spawn(Enemy a_enemy); */

/**/
    /*
    WaveManager::CheckEnemyCount WaveManager::CheckEnemyCount

    NAME
        WaveManager::CheckEnemyCount - checks the amount of enemies

    SYNOPSIS
        private int CheckEnemyCount(EnemyWave a_wave); 
            a_wave -> references the current wave
        
    DESCRIPTION
        This function is responsible for counting the amount of living
        enemies on screen every round.

    RETURNS
        returns the currentCount int

    AUTHOR
        Albert Carbillas

    DATE
        8/20/2019
    */
/**/
    private int CheckEnemyCount(EnemyWave a_wave)
    {
        // the current count is set to the specified enemy count of the current wave
        int currentCount = a_wave.EnemyCount; 

        // this is set to combat any erroneous loss of enemies in the total count
        // because of unexpected collisions between object or double hitting dead enemies. 
        // if count every goes below 0 then default to 0
        if (currentCount < 0)
        {
            currentCount = 0;
        }

        return currentCount;
    }
/* private int CheckEnemyCount(EnemyWave a_wave); */

/**/
    /*
    WaveManager::NextWave WaveManager::NextWave

    NAME
        WaveManager::NextWave - sets up the next wave

    SYNOPSIS
        private void NextWave(); 
        
    DESCRIPTION
        This function is responsible for entering the next wave. It also checks 
        for various things like to see if the game is finished or signals the next round
        to the game manager

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/20/2019
    */
/**/
    private void NextWave()
    {
        // set to counting state
        m_currentState = WaveState.COUNTING;

        // add new wave delay
        m_initWaveDelay = m_waveDelay;

        // if all rounds have been completed then start loop back to the beginning
        // the game manager will prompt the user if they want to 
        if (WaveIndex + 1 > m_waves.Length - 1)
        {
            GameManager.Manager.m_isGameFinished = true;
            WaveIndex = 0;
            GameManager.Manager.WaveCount = WaveIndex;
            GameManager.Manager.m_wasPrompted = false;
            return;
        }

        // increments to the next wave
        WaveIndex++;
        GameManager.Manager.WaveCount = WaveIndex;
        GameManager.Manager.m_wasPrompted = false;
    }
/* private void NextWave(); */

/**/
    /*
    WaveManager::SetEnemyType WaveManager::SetEnemyType

    NAME
        WaveManager::SetEnemyType - sets the type of enemy to be spawned

    SYNOPSIS
        private Enemy SetEnemyType(EnemyWave a_wave); 
            a_wave -> reference to the current wave
        
    DESCRIPTION
        This function is responsible for setting the type of enemy for each round.
        Every 9 rounds will either be a Slime, Goblin, or Skeleton. Every 10th 
        round will be a boss version of each type.

    RETURNS
        Value of type enemy which will be the current type to use

    AUTHOR
        Albert Carbillas

    DATE
        8/20/2019
    */
/**/
    private Enemy SetEnemyType(EnemyWave a_wave)
    {
        Enemy type = null;

        // looks to see which type to use for every round 
        // the enemy types are specified in an array in the EnemyWave class
        switch (WaveIndex)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
                type = a_wave.m_enemyList[0];
                break;
            case 9:
                type = a_wave.m_enemyList[1];
                break;
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
                type = a_wave.m_enemyList[2];
                break;
            case 19:
                type = a_wave.m_enemyList[3];
                break;
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
            case 25:
            case 26:
            case 27:
            case 28:
                type = a_wave.m_enemyList[4];
                break;
            case 29:
                type = a_wave.m_enemyList[5];
                break;
        }

        return type;
    }
/* private Enemy SetEnemyType(EnemyWave a_wave); */

/**/
    /*
    WaveManager::SetEnemyCount WaveManager::SetEnemyCount

    NAME
        WaveManager::SetEnemyCount - sets the amount of enemies per wave

    SYNOPSIS
        private int SetEnemyCount(EnemyWave a_wave); 
            a_wave -> reference to the current wave
        
    DESCRIPTION
        This function is responsible for setting the amount of enemies each wave 
        will need to spawn. Starting with 1, each wave will have +1 enemies. 
        Every 10th round will be replaced with 1 boss.

    RETURNS
        int value of the amount of enemies to spawn

    AUTHOR
        Albert Carbillas

    DATE
        8/20/2019
    */
/**/
    private int SetEnemyCount(EnemyWave a_wave)
    {
        int count = 0;

        switch (WaveIndex)
        {
            case 0:
                count = 1;
                break;
            case 1:
                count = 2;
                break;
            case 2:
                count = 3;
                break;
            case 3:
                count = 4;
                break;
            case 4:
                count = 5;
                break;
            case 5:
                count = 6;
                break;
            case 6:
                count = 7;
                break;
            case 7:
                count = 8;
                break;
            case 8:
                count = 9;
                break;
            case 9:
                count = 1;
                break;
            case 10:
                count = 1;
                break;
            case 11:
                count = 2;
                break;
            case 12:
                count = 3;
                break;
            case 13:
                count = 4;
                break;
            case 14:
                count = 5;
                break;
            case 15:
                count = 6;
                break;
            case 16:
                count = 7;
                break;
            case 17:
                count = 8;
                break;
            case 18:
                count = 9;
                break;
            case 19:
                count = 1;
                break;
            case 20:
                count = 1;
                break;
            case 21:
                count = 2;
                break;
            case 22:
                count = 3;
                break;
            case 23:
                count = 4;
                break;
            case 24:
                count = 5;
                break;
            case 25:
                count = 6;
                break;
            case 26:
                count = 7;
                break;
            case 27:
                count = 8;
                break;
            case 28:
                count = 9;
                break;
            case 29:
                count = 1;
                break;
        }

        return count;
    }
/* private int SetEnemyCount(EnemyWave a_wave); */
}
