using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private static Player plyr; // class object for singleton 

    private float m_baseHealth;
    private Vector3 m_min;
    private Vector3 m_max;

/**/
    /*
    Player::Start() Player::Start()

    NAME
        Player::Start - initializes the Player class objects

    SYNOPSIS
        protected override void Player::Start(); 
       
    DESCRIPTION
        This function is responsible for acting as a constructor for the Player
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it initalizes certain 
        player-specific stats and calls back the base class Start function.
    
        Start is called before the first frame update.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        2/16/2019
    */
/**/
    protected override void Start()
    {
        plyr = this;
        m_baseHealth = 100;
        m_health.Initialize(m_baseHealth, m_baseHealth);
        Speed = 1.75f; 
        BaseAttackDamage = 2; 
        base.Start();
    }
/* protected override void Player::Start(); */

/**/
    /*
    Player::Update() Player::Update()

    NAME
        Player::Update - updates the state of the Enemy class objects

    SYNOPSIS
        protected override void Player::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the Player class' objects by checking its current 
        state and values frame by frame. The values and states that are to be 
        tracked are specified in the body of the function. 

        This first makes the necessary updates for player-specific values
        and then jumps back to the character class to perform general updates
        
        Update is called once per frame.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        2/16/2019
    */
/**/
    protected override void Update()
    {
        // Actively checks to see if the player is providing any key inputs
        GetInput();

        // These lines lock the camera position to the player 
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, m_min.x, m_max.x), 
        Mathf.Clamp(transform.position.y, m_min.y, m_max.y), transform.position.z);

        base.Update();
    }
/* protected override void Player::Update(); */

/**/
    /*
    Player::FixedUpdate() Player::FixedUpdate()

    NAME
        Player::FixedUpdate - updates the state of the Player physics

    SYNOPSIS
        protected void Player::FixedUpdate(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater specifically 
        for physics calculations. This allows for the use of movement manpipulation 
        that is independent of frames. 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        2/20/2019
    */
/**/
    protected void FixedUpdate()
    {
        Move();
    }
/* protected void Player::FixedUpdate(); */

/**/
    /*
    Player::IsDead Player::IsDead

    NAME
        Player::IsDead - gets the boolean value of IsDead

    SYNOPSIS
        public override bool Player::IsDead; 
        
    DESCRIPTION
        This accessor function is repsonsible for getting the current value of IsDead 
        to determine whether or not the player is currently dead. 

    RETURNS
        true -> if player is dead
        false -> if player is not dead

    AUTHOR
        Albert Carbillas

    DATE
        2/16/2019
    */
/**/
    public override bool IsDead
    {
        get
        {
            return m_health.MyCurrentValue <= 0;
        }
    }
/* public override void Player::IsDead; */

/**/
    /*
    Player::BaseHealth Player::BaseHealth

    NAME
        Player::BaseHealth - gets the boolean value of BaseHealth

    SYNOPSIS
        public override bool Player::BaseHealth; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_baseHealth 

    RETURNS
        float value of m_baseHealth

    AUTHOR
        Albert Carbillas

    DATE
        2/16/2019
    */
/**/
    public float BaseHealth
    {
        get
        {
            return m_baseHealth;
        }

        set
        {
            m_baseHealth = value;
        }
    }
/* public float Player::BaseHealth; */

/**/
    /*
    Player::Plyr Player::Plyr

    NAME
        Player::Plyr - gets/sets the class object m_plyr

    SYNOPSIS
        public static Player Player::Plyr; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_plyr

        This is a singleton object that will be used to manipulate values in this class within other classes

    RETURNS
        Class value of m_plyr

    AUTHOR
        Albert Carbillas

    DATE
        2/16/2019
    */
/**/
    public static Player Plyr
    {
        get
        {
            return plyr;
        }

        set
        {
            plyr = value;
        }
    }
/* public static Player Player::Plyr; */

/**/
    /*
    Player::GetInput() Player::GetInput()

    NAME
        Player::GetInput - gets the boolean value of BaseHealth

    SYNOPSIS
        private void Player::GetInput(); 
        
    DESCRIPTION
        This function is responsible for tracking user input and responding 
        with the appropriate action.

    RETURNS
        float value of m_baseHealth

    AUTHOR
        Albert Carbillas

    DATE
        2/16/2019
    */
/**/
    private void GetInput()
    {
        // Direction is set to 0 by default
        // Player is standing still to start
        Direction = Vector2.zero;

        // The four arrow keys act as movement inputs along
        // the x and y axis

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Direction += Vector2.up; 
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Direction += Vector2.left; 
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Direction += Vector2.down;             
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Direction += Vector2.right;             
        }

        // if the input is Space then trigger an attack 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!m_isAttacking && !IsMoving) 
            {
                // Coroutine allows us to do something simultaneously as the script is running
                m_attackRoutine = StartCoroutine(Attack());
            }
        }
    }
/* private void Player::GetInput(); */

/**/
    /*
    Player::SetLimits() Player::SetLimits()

    NAME
        Player::SetLimits - sets the limits of the x and y relative to the camera

    SYNOPSIS
        public void Player::SetLimits(Vector3 a_min, Vector3 a_max); 
            a_min -> stores the minimum vector3 coordinates for the camera follow
            a_max -> stores the minimum vector3 coordinates for the camera follow

    DESCRIPTION
        This function is responsible for setting vector limits relative to the player 
        and the world camera. This is so that the camera does not move further than 
        the player's current position.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        2/20/2019
    */
/**/
    public void SetLimits(Vector3 a_min, Vector3 a_max)
    {
        m_min = a_min; 
        m_max = a_max;
    }
/* public void Player::SetLimits(Vector3 a_min, Vector3 a_max); */

/**/
    /*
    Player::Attack() Player::Attack()

    NAME
        Player::Attack - runs a timed attack routine

    SYNOPSIS
        private IEnumerator Player::Attack(); 

    DESCRIPTION
        This function is responsible for initalizing the attack animation 
        and triggering an attack delay once the attack is made. This prevents
        the player from spamming their attack. 

    RETURNS
        IEnumerator 

    AUTHOR
        Albert Carbillas

    DATE
        2/16/2019
    */
/**/
    private IEnumerator Attack()
    {
        m_isAttacking = true;
        m_animator.SetBool("attack", m_isAttacking);
        yield return new WaitForSeconds(0.5F); 
        StopAttack();
    }
/* private IEnumerator Player::Attack(); */

/**/
    /*
    Player::Move() Player::Move()

    NAME
        Player::Move - moves the player

    SYNOPSIS
        public void Player::Move(); 

    DESCRIPTION
        This function is responsible for moving the player as long as they
        are alive. This is done with the physics system and moving the player
        object based on its velocity and direction.

    RETURNS
        ((void)) 

    AUTHOR
        Albert Carbillas

    DATE
        2/16/2019
    */
/**/
    public void Move()
    {
        if (IsAlive)
        {
            // Vector is normalized to prevent over acceleration when 
            // moving diagonally
            m_myRigidBody.velocity = Direction.normalized * Speed;
        }
    }
/* public void Player::Move(); */

/**/
    /*
    Player::SavePlayer() Player::SavePlayer()

    NAME
        Player::SavePlayer - saves the player's data

    SYNOPSIS
        public void Player::SavePlayer(); 

    DESCRIPTION
        This function is responsible for calling the SaveDataManager class
        and saving the player's important data that needs to be stored on file for 
        serialization.

    RETURNS
        ((void)) 

    AUTHOR
        Albert Carbillas

    DATE
        9/3/2019
    */
/**/
    public void SavePlayer()
    {
        SaveDataManager.SavePlayer(this);
    }
/* public void Player::SavePlayer(); */

/**/
    /*
    Player::LoadPlayer() Player::LoadPlayer()

    NAME
        Player::LoadPlayer - loads the player's data

    SYNOPSIS
        public void Player::LoadPlayer(); 

    DESCRIPTION
        This function is responsible for calling the SaveDataManager class
        and loading the player's important data that needs to be accessed on file for 
        reloading a previous state of the game.

    RETURNS
        ((void)) 

    AUTHOR
        Albert Carbillas

    DATE
        9/3/2019
    */
/**/
    public void LoadPlayer()
    {
        // Calls the Save Manager Load function 
        PlayerSaveData saveData = SaveDataManager.LoadPlayer();

        // reinitializes the player's health so the saved values
        m_health.Initialize(saveData.m_currHealth, saveData.m_maxHealth);
        
        // reintializes all the stats to what was saved on file
        BaseAttackDamage = saveData.m_attackDamage;
        Speed = saveData.m_speed;

        Vector3 position;
        position.x = saveData.m_postion[0];
        position.y = saveData.m_postion[1];
        position.z = saveData.m_postion[2];
        transform.position = position;
    }
/* public void Player::LoadPlayer(); */
}
