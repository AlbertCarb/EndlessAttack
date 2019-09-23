using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    [SerializeField]
    private float m_lerpSpeed; // speed in which the health bar decreases 

    [SerializeField]
    private Text m_healthValue; // the text value of a character's health

    private Image m_content; // reference to the healthbar icon
    private float m_currentFill; // current fill value of how much the bar is filled 
    private float m_currentValue; // current health value
   
/**/
    /*
    Stat::Start() Stat::Start()

    NAME
        Stat::Start - initializes the Stat class objects

    SYNOPSIS
        void Stat::Start(); 
       
    DESCRIPTION
        This function is responsible for acting as a constructor for the Stat
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it initalizes certain 
        Stat-specific stats.
    
        Start is called before the first frame update.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        4/16/2019
    */
/**/
    void Start()
    {
        m_content = GetComponent<Image>();
    }
/* void Stat::Start(); */

/**/
    /*
    Stat::Update() Stat::Update()

    NAME
        Stat::Update - updates the state of the Stat class objects

    SYNOPSIS
        void Stat::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the Stat class' objects by checking its current 
        state and values frame by frame. The values and states that are to be 
        tracked are specified in the body of the function. 
        
        Update is called once per frame.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        4/16/2019
    */
/**/
    void Update()
    {
        // if the current fill is equal to the image on screen 
        // then decrease the fill amount to the current fill by the lerp speed
        // this will give the effect of the health bar going down
        if (m_currentFill != m_content.fillAmount) 
        {
            m_content.fillAmount = Mathf.Lerp(m_content.fillAmount, m_currentFill, Time.deltaTime * m_lerpSpeed);
        }
    }
/* void Stat::Update(); */

/**/
    /*
    Stat::MyMaxValue Stat::MyMaxValue

    NAME
        Stat::MyMaxValue - gets/sets the float value of MyMaxValue

    SYNOPSIS
        public float Stat::MyMaxValue; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the public property MyMaxValue

    RETURNS
        float value of MyMaxValue

    AUTHOR
        Albert Carbillas

    DATE
        4/16/2019
    */
/**/
    public float MyMaxValue
    {
        get;
        set;
    }
/* public float Stat::MyMaxValue; */

/**/
    /*
    Stat::MyCurrentValue Stat::MyCurrentValue

    NAME
        Stat::MyCurrentValue - gets/sets the float value of MyCurrentValue

    SYNOPSIS
        public float Stat::MyCurrentValue; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private property m_currentValue

    RETURNS
        float value of m_currentValue

    AUTHOR
        Albert Carbillas

    DATE
        4/16/2019
    */
/**/
    public float MyCurrentValue
    {
        get
        {
            return m_currentValue;
        }

        set
        {
            // if the set value is more than the intended max then 
            // set it to the max
            if (value > MyMaxValue)
            {
                m_currentValue = MyMaxValue;
            }
            else if (value < 0) // if it's set below 0 then default to 0
            {
                m_currentValue = 0;
            }
            else // otherwise set the current value to value
            {
                m_currentValue = value;
            }

            // this will store the amount the bar will be filled on screen
            m_currentFill = m_currentValue / MyMaxValue;

            // if the health value is not null then set that value's text
            // to the current value out of the max value
            if (m_healthValue != null)
            {
                m_healthValue.text = m_currentValue + "/" + MyMaxValue;
            }
        }
    }
/* public float Stat::MyCurrentValue; */

/**/
    /*
    Stat::Initialize Stat::Initialize

    NAME
        Stat::Initialize - intializes the health values

    SYNOPSIS
        public void Stat::Initialize(float a_currentValue, float a_maxValue);
            a_currentValue -> the current value of the character
            a_maxValue -> the max value of the character
        
    DESCRIPTION
        This function is responsible for intializing the current and max health 
        values of a character

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        4/16/2019
    */
/**/
    public void Initialize(float a_currentValue, float a_maxValue)
    {
        MyMaxValue = a_maxValue; 
        MyCurrentValue = a_currentValue;  
    }
/* public void Stat::Initialize(float a_currentValue, float a_maxValue); */
}