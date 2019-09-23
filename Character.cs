using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{   
    public Stat m_health; // health value of type Stat

    protected float m_speed; // value for character's movement speed 
    protected float m_baseAttackDamage; // value for character's attack damage 
    protected float m_initHealth; // value for character's initial health, player's health can change if they boost their stat
    protected Animator m_animator; // reference to the character object's animator component 
    protected Rigidbody2D m_myRigidBody; // reference to the character object's physics skeleton or rigidbody
    protected bool m_isAttacking; // value to check is a player is currently attacking 
    protected Coroutine m_attackRoutine; // value to store the attack routiune of the character

    private Vector2 m_direction; // value for the direction a character is facing 
    private bool m_tookDamage; // value to check if a character has taken damage already

/**/
    /*
    Character::Start() Character::Start()

    NAME
        Character::Start - initializes the Character class objects

    SYNOPSIS
        protected virtual void Character::Start(); 
        
    DESCRIPTION
        This function is responsible for acting as a constructor for the Character
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it creates references to a 
        character's Rigidbody object as well as it's animator object. 
        
        Start is called before the first frame update.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        2/15/2019
    */
/**/
    protected virtual void Start()
    {
        m_myRigidBody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }
/* protected virtual void Character::Start(); */

/**/
    /*
    Character::Update() Character::Update()

    NAME
        Character::Update - updates the state of the Character class objects 

    SYNOPSIS
        protected virtual void Character::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the Character class' objects by checking its current 
        state and values frame by frame. The values and states that are to be 
        tracked are specified in the body of the function. 
        
        Update is called once per frame.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        2/15/2019
    */
/**/
    protected virtual void Update()
    {
       HandleLayers();
    }
/* protected virtual void Character::Update(); */

/**/
    /*
    Character::IsDead Character::IsDead

    NAME
        Character::IsDead - gets the boolean value of IsDead

    SYNOPSIS
        public abstract bool IsDead; 
        
    DESCRIPTION
        This accessor function is repsonsible for getting the current value of IsDead 
        to determine whether or not a character is currently dead. 

    RETURNS
        true -> if character is dead
        false -> if character is not dead

    AUTHOR
        Albert Carbillas

    DATE
        2/15/2019
    */
/**/
    public abstract bool IsDead 
    { 
        get; 
    }
/* public abstract bool Character::IsDead; */

/**/
    /*
    Character::IsMoving Character::IsMoving

    NAME
        Character::IsMoving - gets the boolean value of m_isMoving

    SYNOPSIS
        public bool IsMoving; 
        
    DESCRIPTION
        This accessor function is repsonsible for getting the current value of the 
        protected variable m_isMoving to determine whether or not a character is currently 
        moving. 

    RETURNS
        true -> if character is moving
        false -> if character is not moving

    AUTHOR
        Albert Carbillas

    DATE
        2/15/2019
    */
/**/
    public bool IsMoving
    {
        get 
        {
            return Direction.x != 0 || Direction.y != 0;
        }
    }
/* public bool Character::IsMoving; */


/**/
    /*
    Character::Direction Character::Direction

    NAME
        Character::Direction - gets/sets the current value of m_direction

    SYNOPSIS
        public Vector2 Direction; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting the current value of the 
        private variable m_direction to determine the current direction of the character. 

    RETURNS
        Vector2 value of the current direction that character is facing

    AUTHOR
        Albert Carbillas

    DATE
        2/15/2019
    */
/**/
    public Vector2 Direction
    {
        get
        {
            return m_direction;
        }

        set
        {
            m_direction = value;
        }
    }
/* public Vector2 Character::Direction; */


/**/
    /*
    Character::Speed Character::Speed

    NAME
        Character::Speed - gets/sets the current value of m_speed

    SYNOPSIS
        public float Character::Speed; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting the current value of the 
        protected variable m_speed to determine the current speed of the character. 

    RETURNS
        float value for the speed of the character 

    AUTHOR
        Albert Carbillas

    DATE
        2/15/2019
    */
/**/
    public float Speed
    {
        get
        {
            return m_speed;
        }

        set
        {
            m_speed = value;
        }
    }
/* public Vector2 Character::Speed; */


/**/
    /*
    Character::IsAlive Character::IsAlive

    NAME
        Character::IsAlive - gets the boolean value of IsAlive

    SYNOPSIS
        public bool Character::IsAlive; 
        
    DESCRIPTION
        This accessor function is repsonsible for getting the current value of IsAlive 
        to determine whether or not a character is currently alive. 

    RETURNS
        true -> if current health is above 0 
        false -> if current heealth is below 0

    AUTHOR
        Albert Carbillas

    DATE
        2/15/2019
    */
/**/
    public bool IsAlive
    {
        get 
        {
            return m_health.MyCurrentValue > 0;
        }
    }
/* public bool Character::IsAlive; */

/**/
    /*
    Character::TookDamage Character::TookDamage

    NAME
        Character::TookDamage - gets the boolean value of TookDamage

    SYNOPSIS
        public bool Character::TookDamage; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting/setting the current value of the
        private variable m_tookDamage to determine whether or not a character is damaged. 

    RETURNS
        true -> if character took damage
        false -> if character did not take damage

    AUTHOR
        Albert Carbillas

    DATE
        2/15/2019
    */
/**/
    public bool TookDamage
    {
        get
        {
            return m_tookDamage;
        }

        set
        {
            m_tookDamage = value;
        }
    }
/* public bool Character::TookDamage; */

/**/
    /*
    Character::BaseAttackDamage Character::BaseAttackDamage

    NAME
        Character::BaseAttackDamage - gets the boolean value of m_baseAttackDamage

    SYNOPSIS
        public float Character::BaseAttackDamage; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting/setting the current value of the
        protected variable m_baseAttackDamage to determine the current value of a character's attack
        damage. 

    RETURNS
        float value for the attack damage of a character

    AUTHOR
        Albert Carbillas

    DATE
        2/15/2019
    */
/**/
    public float BaseAttackDamage
    {
        get
        {
            return m_baseAttackDamage;
        }

        set
        {
            m_baseAttackDamage = value;
        }
    }
/* public float Character::BaseAttackDamage; */

/**/
    /*
    Character::HandleLayers() Character::HandleLayers()

    NAME
        Character::HandleLayers - manages the different types of animation for a character

    SYNOPSIS
        public void Character::HandleLayers(); 
        
    DESCRIPTION
        This function is reponsible for transition between animation layers depending
        on the state of the character. 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        2/17/2019
    */
/**/
    public void HandleLayers()
    {
        if (IsAlive)
        {
            // if character is alive AND Movie then activate run layer
            // animator moves relative to the x and y position it is facing
            // Any attacks are stopped when moving
            if (IsMoving)
            {
                ActivateLayer("RunLayer");
                m_animator.SetFloat("x", Direction.x);
                m_animator.SetFloat("y", Direction.y);
                StopAttack();
            } 
            else if (m_isAttacking)
            {
                // if attacking then activate attack layer and stop movement
                ActivateLayer("AttackLayer");
            }
            else 
            {
                // else character is standing still so activate idle layer
                ActivateLayer("IdleLayer");
            }
        }
        else
        {
            // if character isn't alive then activate death layer
            ActivateLayer("DeathLayer");
        }
    }
/* public void Character::HandleLayers(); */

/**/
    /*
    Character::ActivateLayer() Character::ActivateLayer()
    NAME
        Character::ActivateLayer - activates the current animation layer

    SYNOPSIS
        public void Character::ActivateLayer(string a_layerName); 
            a_layerName -> the name of the layer to be activated in the Animator
        
    DESCRIPTION
        This function is reponsible for activating a current animation
        layer. 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        2/17/2019
    */
/**/
    public void ActivateLayer(string a_layerName)
    {
        // the for loop goes to each animation and sets it's weight 
        // or priority to 0
        for (int i = 0; i < m_animator.layerCount; i++)
        {
            m_animator.SetLayerWeight(i, 0);
        }

        // activates the layer stored in the parameter 
        m_animator.SetLayerWeight(m_animator.GetLayerIndex(a_layerName), 1);
    }
/* public void Character::ActivateLayer(string a_layerName); */

/**/
    /*
    Character::StopAttack() Character::StopAttack()
    NAME
        Character::StopAttack - stops the character's attack

    SYNOPSIS
        public void Character::StopAttack(); 
        
    DESCRIPTION
        This function is reponsible for stopping the attack animation of 
        the character

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        2/17/2019
    */
/**/
    public void StopAttack()
    {
        // checks to see if the coroutine is currently null
        // if not then stop the attack routine and reset the character's
        // attack state
        if (m_attackRoutine != null)
        {
            StopCoroutine(m_attackRoutine);
            m_isAttacking = false;
            m_animator.SetBool("attack", m_isAttacking);            
        }
    }
/* public void Character::StopAttack(); */

/**/
    /*
    Character::TakeDamage() Character::TakeDamage()
    NAME
        Character::TakeDamage - inflicts damage onto the character

    SYNOPSIS
        public void Character::TakeDamage(float a_damage); 
            a_damage -> the float value of the damage a character takes
        
    DESCRIPTION
        This function is reponsible for applying damage to a character
        after they have been attacked. The value of the damage parameter is subtracted 
        from the current value of the character's health. If their health reaches 0
        then their state is changed to "die". 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        2/17/2019
    */
/**/
    public virtual void TakeDamage(float a_damage)
    {
        m_health.MyCurrentValue -= a_damage;
        TookDamage = true;

        // if character is dead then halt their movement and velocity
        // their physics is set to kinematic which makes the unmmovable unless
        // done through the script
        if (IsDead)
        {
            Direction = Vector2.zero; 
            m_myRigidBody.velocity = Direction;
            m_myRigidBody.isKinematic = true;
            m_animator.SetTrigger("die");

            // if the current character that dies is an enemy
            // then decrement the current enemy count by one
            if (this.tag == "Enemy")
            {
               EnemyWave.EWave.EnemyCount--;
            }
        }
        else // if not dead then enable damage animation 
        {
            EnableFlash();
        }
    }
/* public void Character::TakeDamage(float a_damage); */

/**/
    /*
    Character::EnableFlash() Character::EnableFlash()
    NAME
        Character::EnableFlash - activates a damage animation 

    SYNOPSIS
        public void Character::EnableFlash(); 
        
    DESCRIPTION
        This function is reponsible for applying a damage animation whenever
        a character gets hit. This is done by manipualting the alpha channel 
        in the character sprite's color settings. By flippin the alpha channel 
        on and off, then it is able to create a blinking effect whenever the character 
        is hit. 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        6/10/2019
    */
/**/
    public void EnableFlash()
    {
        if (this.tag == "Enemy" && TookDamage == true)
        {
            EnemyHealthManager.EnemyHealth.FlashActive = true;
            EnemyHealthManager.EnemyHealth.FlashCounter = EnemyHealthManager.EnemyHealth.FlashLength;
        }
        else if (this.tag == "Player" && TookDamage == true)
        {
            PlayerHealthManager.PlayerHealth.FlashActive = true;
            PlayerHealthManager.PlayerHealth.FlashCounter =  PlayerHealthManager.PlayerHealth.FlashLength;
        }
    }
/* public void Character::EnableFlash(); */
}