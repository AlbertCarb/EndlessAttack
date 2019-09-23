using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    private bool m_flashActive; // bool value to see if the flash is active
    private float m_flashCounter = 0f; // counts the amount of time a sprite has flashed 
    private float m_flashLength = 0.5f; // duration of the flashes
    
    private SpriteRenderer m_enemySprite; // reference to the enemy's sprite art. we need this to manipulate the color 
    private Enemy m_character; // reference to the enemy 
    private static EnemyHealthManager m_enemyHealth; // the class object will be using in our singleton design for this class

/**/
    /*
    EnemyHealthManager::Start() EnemyHealthManager::Start()

    NAME
        EnemyHealthManager::Start - initializes the EnemyHealthManager class objects

    SYNOPSIS
        void EnemyHealthManager::Start(); 

    DESCRIPTION
        This function is responsible for acting as a constructor for the EnemyHealthManager
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it initalizes certain 
        EnemyHealthManager-specific stats.

        Start is called before the first frame update.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        7/1/2019
    */
/**/
    void Start()
    {
        EnemyHealth = this;
        m_enemySprite = GetComponent<SpriteRenderer>();
        m_character = (Enemy)FindObjectOfType(typeof(Enemy));
    }
/* void EnemyHealthManager::Start(); */

/**/
    /*
    EnemyHealthManager::Update() EnemyHealthManager::Update()

    NAME
        EnemyHealthManager::Update - updates the state of the EnemyHealthManager class objects

    SYNOPSIS
        void EnemyHealthManager::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the EnemyHealthManager class' objects by checking its current 
        state and values frame by frame. The values and states that are to be 
        tracked are specified in the body of the function. 
        
        Update is called once per frame.

        This will activate the flash effect on the enemy

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        7/1/2019
    */
/**/
    void Update()
    {
        // if flash is active then activate flash effect on every frame as long as count is greater than 0f 
        // we are changing the color of the sprite's alpha channel to maniuplate the transparency of the image 
        // switching transparency to on and off 
        if (FlashActive)
        {
            if (FlashCounter > FlashLength * .99f)
            {
                m_enemySprite.color = new Color(m_enemySprite.color.r, m_enemySprite.color.g, m_enemySprite.color.b, 0f);
            }
            else if (FlashCounter > FlashLength * .82f)
            {
                m_enemySprite.color = new Color(m_enemySprite.color.r, m_enemySprite.color.g, m_enemySprite.color.b, 1f);
            }
            else if (FlashCounter > FlashLength * .66f)
            {
                m_enemySprite.color = new Color(m_enemySprite.color.r, m_enemySprite.color.g, m_enemySprite.color.b, 0f);
            }
            else if (FlashCounter > FlashLength * .49f)
            {
                m_enemySprite.color = new Color(m_enemySprite.color.r, m_enemySprite.color.g, m_enemySprite.color.b, 1f);
            }
            else if (FlashCounter > FlashLength * .33f)
            {
                m_enemySprite.color = new Color(m_enemySprite.color.r, m_enemySprite.color.g, m_enemySprite.color.b, 0f);
            }
            else if (FlashCounter > FlashLength * .16f)
            {
                m_enemySprite.color = new Color(m_enemySprite.color.r, m_enemySprite.color.g, m_enemySprite.color.b, 1f);
            }
            else if (FlashCounter > 0f)
            {
                m_enemySprite.color = new Color(m_enemySprite.color.r, m_enemySprite.color.g, m_enemySprite.color.b, 0f);
            }
            else
            {
                m_enemySprite.color = new Color(m_enemySprite.color.r, m_enemySprite.color.g, m_enemySprite.color.b, 1f);
                FlashActive = false;        
            }

            FlashCounter -= Time.deltaTime;
        }
    }
/* void EnemyHealthManager::Update(); */

/**/
    /*
    EnemyHealthManager::EnemyHealth EnemyHealthManager::EnemyHealth

    NAME
        EnemyHealthManager::EnemyHealth - gets/sets the class object m_enemyHealth

    SYNOPSIS
        public static EnemyHealthManager::EnemyHealth; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_enemyHealth

        This is a singleton object that will be used to manipulate values in this class within other classes

    RETURNS
        Class value of m_enemyHealth

    AUTHOR
        Albert Carbillas

    DATE
        7/1/2019
    */
/**/
    public static EnemyHealthManager EnemyHealth
    {
        get
        {
            return m_enemyHealth;
        }

        set
        {
            m_enemyHealth = value;
        }
    }
/* public static EnemyHealthManager::EnemyHealth; */

/**/
    /*
    EnemyHealthManager::FlashActive EnemyHealthManager::FlashActive

    NAME
        EnemyHealthManager::FlashActive - gets/sets the boolean value of FlashActive

    SYNOPSIS
        public bool EnemyHealthManager::FlashActive; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_flashActive 

    RETURNS
        bool value of m_flashActive

    AUTHOR
        Albert Carbillas

    DATE
        7/1/2019
    */
/**/
    public bool FlashActive
    {
        get
        {
            return m_flashActive;
        }

        set
        {
            m_flashActive = value;
        }
    }
/* public bool EnemyHealthManager::FlashActive; */

/**/
    /*
    EnemyHealthManager::FlashCounter EnemyHealthManager::FlashCounter

    NAME
        EnemyHealthManager::FlashCounter - gets/sets the boolean value of FlashCounter

    SYNOPSIS
        public float EnemyHealthManager::FlashCounter; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_flashCounter

    RETURNS
        float value of m_flashCounter

    AUTHOR
        Albert Carbillas

    DATE
        7/1/2019
    */
/**/
    public float FlashCounter
    {
        get
        {
            return m_flashCounter;
        }

        set
        {
            m_flashCounter = value;
        }
    }
/* public float EnemyHealthManager::FlashCounter; */

/**/
    /*
    EnemyHealthManager::FlashLength EnemyHealthManager::FlashLength

    NAME
        EnemyHealthManager::FlashLength - gets/sets the boolean value of FlashLength

    SYNOPSIS
        public float EnemyHealthManager::FlashLength; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_flashLength

    RETURNS
        float value of m_flashLength

    AUTHOR
        Albert Carbillas

    DATE
        7/1/2019
    */
/**/
    public float FlashLength
    {
        get
        {
            return m_flashLength;
        }

        set
        {
            m_flashLength = value;
        }
    }
/* public float EnemyHealthManager::FlashLength; */
}