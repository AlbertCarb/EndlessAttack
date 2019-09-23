using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    private bool m_flashActive; // bool value to see if the flash is active
    private float m_flashCounter = 0f; // counts the amount of time a sprite has flashed
    private float m_flashLength = 0.5f; // duration of the flashes
    
    private SpriteRenderer m_playerSprite; // reference to the enemy's sprite art. we need this to manipulate the color
    private Player m_character; // reference to the enemy
    private static PlayerHealthManager m_playerHealth; // the class object will be using in our singleton design for this class

/**/
    /*
    PlayerHealthManager::Start() PlayerHealthManager::Start()

    NAME
        PlayerHealthManager::Start - initializes the PlayerHealthManager class objects

    SYNOPSIS
        void PlayerHealthManager::Start(); 

    DESCRIPTION
        This function is responsible for acting as a constructor for the PlayerHealthManager
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it initalizes certain 
        PlayerHealthManager-specific stats.

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
        PlayerHealth = this;
        m_playerSprite = GetComponent<SpriteRenderer>();
        m_character = (Player)FindObjectOfType(typeof(Player));
    }
/* void PlayerHealthManager::Start(); */

/**/
    /*
    PlayerHealthManager::Update() PlayerHealthManager::Update()

    NAME
        PlayerHealthManager::Update - updates the state of the PlayerHealthManager class objects

    SYNOPSIS
        void PlayerHealthManager::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the PlayerHealthManager class' objects by checking its current 
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
                m_playerSprite.color = new Color(m_playerSprite.color.r, m_playerSprite.color.g, m_playerSprite.color.b, 0f);
            }
            else if (FlashCounter > FlashLength * .82f)
            {
                m_playerSprite.color = new Color(m_playerSprite.color.r, m_playerSprite.color.g, m_playerSprite.color.b, 1f);
            }
            else if (FlashCounter > FlashLength * .66f)
            {
                m_playerSprite.color = new Color(m_playerSprite.color.r, m_playerSprite.color.g, m_playerSprite.color.b, 0f);
            }
            else if (FlashCounter > FlashLength * .49f)
            {
                m_playerSprite.color = new Color(m_playerSprite.color.r, m_playerSprite.color.g, m_playerSprite.color.b, 1f);
            }
            else if (FlashCounter > FlashLength * .33f)
            {
                m_playerSprite.color = new Color(m_playerSprite.color.r, m_playerSprite.color.g, m_playerSprite.color.b, 0f);
            }
            else if (FlashCounter > FlashLength * .16f)
            {
                m_playerSprite.color = new Color(m_playerSprite.color.r, m_playerSprite.color.g, m_playerSprite.color.b, 1f);
            }
            else if (FlashCounter > 0f)
            {
                m_playerSprite.color = new Color(m_playerSprite.color.r, m_playerSprite.color.g, m_playerSprite.color.b, 0f);
            }
            else
            {
                m_playerSprite.color = new Color(m_playerSprite.color.r, m_playerSprite.color.g, m_playerSprite.color.b, 1f);
                FlashActive = false;        
            }

            FlashCounter -= Time.deltaTime;
        }
    }
/* void PlayerHealthManager::Update(); */

/**/
    /*
    PlayerHealthManager::PlayerHealth PlayerHealthManager::PlayerHealth

    NAME
        PlayerHealthManager::PlayerHealth - gets/sets the class object m_playerHealth

    SYNOPSIS
        public static PlayerHealthManager::PlayerHealth; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_playerHealth

        This is a singleton object that will be used to manipulate values in this class within other classes

    RETURNS
        Class value of m_playerHealth

    AUTHOR
        Albert Carbillas

    DATE
        7/1/2019
    */
/**/
    public static PlayerHealthManager PlayerHealth
    {
        get
        {
            return m_playerHealth;
        }

        set
        {
            m_playerHealth = value;
        }
    }
/* public static PlayerHealthManager::PlayerHealth; */

/**/
    /*
    PlayerHealthManager::FlashActive PlayerHealthManager::FlashActive

    NAME
        PlayerHealthManager::FlashActive - gets/sets the boolean value of FlashActive

    SYNOPSIS
        public bool PlayerHealthManager::FlashActive; 
        
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
/* public bool PlayerHealthManager::FlashActive; */

/**/
    /*
    PlayerHealthManager::FlashCounter PlayerHealthManager::FlashCounter

    NAME
        PlayerHealthManager::FlashCounter - gets/sets the boolean value of FlashCounter

    SYNOPSIS
        public float PlayerHealthManager::FlashCounter; 
        
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
/* public float PlayerHealthManager::FlashCounter; */

/**/
    /*
    PlayerHealthManager::FlashLength PlayerHealthManager::FlashLength

    NAME
        PlayerHealthManager::FlashLength - gets/sets the boolean value of FlashLength

    SYNOPSIS
        public float PlayerHealthManager::FlashLength; 
        
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
/* public float PlayerHealthManager::FlashLength; */
}
