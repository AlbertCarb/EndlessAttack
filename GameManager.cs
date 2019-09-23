using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    private static GameManager m_manager; // singleton object for the class 
    
    public bool m_isGamePaused = false; // bool value if game is paused 
    public bool m_wasPrompted = false; // bool value if the player was prompted with the next round 
    public Button m_saveButton; // Reference to save button object 
    public Button m_loadButton; // Reference to load button object
    public bool m_isGameFinished = false; // bool value if game has been completed 

    private Camera m_mainCamera; // Reference to camera object 
    private int m_waveCount; // value of the current wave 
    private float health; // value of player health after upgrades or resets
    private bool m_isUpgraded = false; // bool value if player has upgraded yet

    [SerializeField]
    private GameObject m_healthText;  // Reference to the health text object on the health bar

    [SerializeField]
    private GameObject m_roundPromptText; // Reference to Round Prompt Text object

    [SerializeField]
    private GameObject m_gameOverPanel; // Reference to game over panel after player has died 

    [SerializeField]
    private GameObject m_statBoostPanel; // Reference to stat boost panel after every 5th round 

    [SerializeField]
    private GameObject m_pauseMenuPanel; // Reference to pause panel when game has been paused

    [SerializeField]
    private GameObject m_continuePanel; // Reference to the continue panel after game is finished 

/**/
    /*
    GameManager::Start() GameManager::Start()

    NAME
        GameManager::Start - initializes the GameManager class objects

    SYNOPSIS
        private void GameManager::Start(); 
       
    DESCRIPTION
        This function is responsible for acting as a constructor for the GameManager
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it initalizes certain 
        GameManager-specific stats.
    
        Start is called before the first frame update.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/23/2019
    */
/**/
    private void Start()
    {
        // The game starts paused
        Pause(m_pauseMenuPanel);

        // sets singleton object and sets the main camera 
        Manager = this;
        m_mainCamera = Camera.main;
    }
/* private void GameManager::Start(); */

/**/
    /*
    GameManager::Update() GameManager::Update()

    NAME
        GameManager::Update - updates the state of the GameManager class objects

    SYNOPSIS
        void GameManager::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the GameManager class' objects by checking its current 
        state and values frame by frame. The values and states that are to be 
        tracked are specified in the body of the function. 
        
        Update is called once per frame.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/23/2019
    */
/**/
    void Update ()
    {
        // if the game is beat then pause the game and prompt the player
        // if they wish to continue or go back to the main menu
        if (m_isGameFinished == true)
        {
            Pause(m_continuePanel);
        }

        // Checks to see if the player has died 
        GameOverCheck();

        // Checks the current wave count
        CheckCurrentWave();

        // if the player has not upgraded their stats yet 
        // then after every 5th round pause the game and prompt 
        // the user to upgrade their stats 
        if (IsUpgraded == false)
        {
            if (WaveCount == 0
            || WaveCount == 5
            || WaveCount == 10
            || WaveCount == 15
            || WaveCount == 20
            || WaveCount == 25)
            {
                // pauses the game and activates stat boost screen 
                Pause(m_statBoostPanel);

                // Resets the players health every 5 rounds 
                ResetPlayerHealth();

                // player has already upgraded so dont prompt again until the next
                // 5 rounds has passed
                IsUpgraded = true;
            }
        }

        // if the player was not prompted 
        // then prompt the user of the next round 
        if (m_wasPrompted == false)
        {
            RoundPrompt();
            m_wasPrompted = true;
        }

        // if the escape key was pressed 
        // then check m_isGamePaused state 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // if true then resume the game and exit pause screen
            if (m_isGamePaused == true)
            {
                Resume(m_pauseMenuPanel);
            }
            // else if false then pause the game 
            else if (m_isGamePaused == false) 
            {
                Pause(m_pauseMenuPanel);
            }
        }
	}
/* void GameManager::Update(); */

/**/
    /*
    GameManager::StatBoost() GameManager::StatBoost()

    NAME
        GameManager::StatBoost - modifies the player's stat of their choice

    SYNOPSIS
        public void GameManager::StatBoost(Button a_btn); 
            a_btn -> the button that the user clicks on 
        
    DESCRIPTION
        This function is responsible for seeing which upgrade button
        the player has clicked and modifying the particular stat
        they have chosen to upgrade

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/23/2019
    */
/**/
    public void StatBoost(Button a_btn)
    {        
        switch(a_btn.name)
        {
            // raises attack damage by a set amount 
            case "StrengthBoostButton":
                Player.Plyr.BaseAttackDamage += 1f; 
                break;
            // raises max health by a set amount 
            case "VitalityBoostButton":
                health = Player.Plyr.BaseHealth += 25;

                // this changes the health text on the health bar
                m_healthText.GetComponent<Text>().text = health.ToString() + "/" + health.ToString();

                // reinitializes the player's health to max
                Player.Plyr.m_health.Initialize(health, health); 
                break;
            // raises movement speed by a set amount 
            case "AgilityBoostButton":
                Player.Plyr.Speed += 0.25f;
                break;
        }

        // unpauses the game
        Resume(m_statBoostPanel);
    }
/* public void GameManager::StatBoost(Button a_btn); */

/**/
    /*
    GameManager::Manager GameManager::Manager

    NAME
        GameManager::Manager - gets/sets the class object m_manager

    SYNOPSIS
        public static GameManager GameManager::Manager; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_manager

        This is a singleton object that will be used to manipulate values in this class within other classes

    RETURNS
        Class value of m_manager

    AUTHOR
        Albert Carbillas

    DATE
        8/23/2019
    */
/**/
    public static GameManager Manager
    {
        get
        {
            return m_manager;
        }

        set
        {
            m_manager = value;
        }
    }
/* public static GameManager GameManager::Manager; */

/**/
    /*
    GameManager::WaveCount GameManager::WaveCount

    NAME
        GameManager::WaveCount - gets/sets the int value of WaveCount

    SYNOPSIS
        public int GameManager::WaveCount; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_waveCount

    RETURNS
        int value of m_waveCount

    AUTHOR
        Albert Carbillas

    DATE
        8/23/2019
    */
/**/
   public int WaveCount
    {
        get
        {
            return m_waveCount;
        }

        set
        {
            m_waveCount = value;
        }
    }
/* public int GameManager::WaveCount; */

/**/
    /*
    GameManager::IsUpgraded GameManager::IsUpgraded

    NAME
        GameManager::IsUpgraded - gets/sets the boolean value of IsUpgraded

    SYNOPSIS
        public bool GameManager::IsUpgraded; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_isUpgraded

    RETURNS
        bool value of m_isUpgraded

    AUTHOR
        Albert Carbillas

    DATE
        8/23/2019
    */
/**/
    public bool IsUpgraded
    {
        get
        {
            return m_isUpgraded;
        }

        set
        {
            m_isUpgraded = value;
        }
    }
/* public bool GameManager::IsUpgraded; */

/**/
    /*
    GameManager::RoundPromptText GameManager::RoundPromptText

    NAME
        GameManager::RoundPromptText - gets/sets the boolean value of RoundPromptText

    SYNOPSIS
        public GameObject GameManager::RoundPromptText; 
        
    DESCRIPTION
        This accessor/mutator function is repsonsible for getting and setting the current value of 
        the private variable m_roundPromptText

    RETURNS
        GameObject value of m_roundPromptText

    AUTHOR
        Albert Carbillas

    DATE
        8/23/2019
    */
/**/
    public GameObject RoundPromptText
    {
        get
        {
            return m_roundPromptText;
        }

        set
        {
            m_roundPromptText = value;
        }
    }
/* public GameObject GameManager::RoundPromptText; */

/**/
    /*
    GameManager::MainMenu GameManager::MainMenu

    NAME
        GameManager::MainMenu - loads the main menu

    SYNOPSIS
        public void GameManager::MainMenu(); 
        
    DESCRIPTION
        This function is responsible for changing the scene from the game to
        the main menu

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/25/2019
    */
/**/
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
/* public void GameManager::MainMenu(); */

/**/
    /*
    GameManager::Resume GameManager::Resume

    NAME
        GameManager::Resume - resumes the game

    SYNOPSIS
        public void GameManager::Resume(GameObject a_menuPanel); 
            a_menuPanel -> the panel object to manipulate on screen
        
    DESCRIPTION
        This function is responsible for resuming the game from 
        the pause state 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/25/2019
    */
/**/
    public void Resume(GameObject a_menuPanel)
    {
        // removes the pause screen of the screen
        a_menuPanel.SetActive(false);

        // Enables the time so the game is no longer frozen 
        Time.timeScale = 1f;
        m_isGamePaused = false;
    } 
/* public void GameManager::Resume(GameObject a_menuPanel); */

/**/
    /*
    GameManager::Pause GameManager::Pause

    NAME
        GameManager::Pause - pauses the game

    SYNOPSIS
        public void GameManager::Pause(GameObject a_menuPanel); 
            a_menuPanel -> the panel object to manipulate on screen
        
    DESCRIPTION
        This function is responsible for pausing and freezing the game

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/25/2019
    */
/**/
    public void Pause(GameObject a_menuPanel)
    {
        // shows the pause menu screen 
        a_menuPanel.SetActive(true);

        // stops time to freeze the game
        Time.timeScale = 0f;
        m_isGamePaused = true;
    }
/* public void GameManager::Pause(GameObject a_menuPanel); */

/**/
    /*
    GameManager::Continue GameManager::Continue

    NAME
        GameManager::Continue - continues the game

    SYNOPSIS
        public void GameManager::Continue(); 
        
    DESCRIPTION
        This function is responsible for contiuing the game 
        and restarting the rounds after the player has completed 
        the game.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/25/2019
    */
/**/
    public void Continue()
    {
        Resume(m_continuePanel);
        m_isGameFinished = false;
    }
/* public void GameManager::Continue(); */

/**/
    /*
    GameManager::Save GameManager::Save

    NAME
        GameManager::Save - saves the game

    SYNOPSIS
        public void GameManager::Save(); 
        
    DESCRIPTION
        This function is responsible for calling the SaveGame
        function.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/3/2019
    */
/**/
    public void Save()
    {
        SaveGame();
    }
/* public void GameManager::Save(); */

/**/
    /*
    GameManager::Load GameManager::Load

    NAME
        GameManager::Load - loads the game

    SYNOPSIS
        public void GameManager::Load(); 
        
    DESCRIPTION
        This function is responsible for calling the LoadGame
        function and loading the proper panels based on the 
        current wave

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/3/2019
    */
/**/
    public void Load()
    {
        LoadGame();

        if (WaveCount != 0
        || WaveCount != 5
        || WaveCount != 10
        || WaveCount != 15
        || WaveCount != 20
        || WaveCount != 25)
        {
            Resume(m_pauseMenuPanel);
            Resume(m_statBoostPanel);
        }
        else 
        {
            m_pauseMenuPanel.SetActive(false);
        }
    }
/* public void GameManager::Load(); */

/**/
    /*
    GameManager::SaveGame GameManager::SaveGame

    NAME
        GameManager::SaveGame - saves the state of the game manager

    SYNOPSIS
        public void GameManager::SaveGame(); 
        
    DESCRIPTION
        This function is responsible for calling the SaveDataManager class
        to save the state of the game manager

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/3/2019
    */
/**/
    public void SaveGame()
    {
        SaveDataManager.SaveGame(this);
    }
/* public void GameManager::SaveGame(); */

/**/
    /*
    GameManager::LoadGame GameManager::LoadGame

    NAME
        GameManager::LoadGame - loads the state of the game manager

    SYNOPSIS
        public void GameManager::LoadGame(); 
        
    DESCRIPTION
        This function is responsible for loading the saved data of the 
        game manager and reinitializing the values to the saved values.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/3/2019
    */
/**/
    public void LoadGame()
    {
        // Deserializes the saved data from file 
        GameSaveData saveData = SaveDataManager.LoadGame();

        // Sets the classes values to the associated save values
        WaveCount = saveData.m_currentRound;
        WaveManager.WManager.WaveIndex = WaveCount;
        RoundPromptText.GetComponent<Text>().text = saveData.m_roundPromptText;
        m_wasPrompted = saveData.m_Prompt;
        m_isGamePaused = saveData.m_gamePause;
        m_isUpgraded = saveData.m_upgraded;
    }
/* public void GameManager::LoadGame(); */

/**/
    /*
    GameManager::Quit GameManager::Quit

    NAME
        GameManager::Quit - quits the game

    SYNOPSIS
        public void GameManager::Quit(); 
        
    DESCRIPTION
        This function is responsible for closing the application

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/25/2019
    */
/**/
    public void Quit()
    {
        Application.Quit();
    }
/* public void GameManager::Quit(); */

/**/
    /*
    GameManager::CheckCurrentWave GameManager::CheckCurrentWave

    NAME
        GameManager::CheckCurrentWave - checks the current wave

    SYNOPSIS
        void GameManager::CheckCurrentWave(); 
        
    DESCRIPTION
        This function is responsible for checking the current wave
        if the wave is right after an upgrade round, then set isUpgraded
        to false.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/25/2019
    */
/**/
    void CheckCurrentWave()
    {
        if (WaveCount == 1
        || WaveCount == 6
        || WaveCount == 11
        || WaveCount == 16
        || WaveCount == 21
        || WaveCount == 26)
        {
            IsUpgraded = false;
        }
    }
/* void GameManager::CheckCurrentWave(); */

/**/
    /*
    GameManager::ResetPlayerHealth GameManager::ResetPlayerHealth

    NAME
        GameManager::ResetPlayerHealth - resets the player's health

    SYNOPSIS
        void GameManager::ResetPlayerHealth(); 
        
    DESCRIPTION
        This function is responsible for resetting the player's health 
        after every 5th round.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/25/2019
    */
/**/
    void ResetPlayerHealth()
    {
        health = Player.Plyr.BaseHealth;
        m_healthText.GetComponent<Text>().text = health.ToString() + "/" + health.ToString();
        Player.Plyr.m_health.Initialize(health, health);
    }
/* void GameManager::ResetPlayerHealth(); */

/**/
    /*
    GameManager::RoundPrompt GameManager::RoundPrompt

    NAME
        GameManager::RoundPrompt - prompts the user with the current round

    SYNOPSIS
        private void GameManager::RoundPrompt(); 
        
    DESCRIPTION
        This function is responsible for prompting the player 
        with the current round at the beginning of each round.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/26/2019
    */
/**/
    private void RoundPrompt()
    {
        // for every case, show the current round 
        // for a set amount of time before disappearing.
        switch (WaveCount)
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
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
            case 25:
            case 26:
            case 27:
            case 28:
            case 29:
                // gets the current wave and adds 1
                int currWave = WaveCount + 1;

                // turns the wave integer into string and concatenate string
                string round = "Round " + currWave.ToString();

                // Starts a coroutine to count a set amount seconds before disabling the prompt
                StartCoroutine(ShowMessage(round));
                break;
        }
    }
/* private void GameManager::RoundPrompt(); */

/**/
    /*
    GameManager::GameOverCheck GameManager::GameOverCheck

    NAME
        GameManager::GameOverCheck - checks to see if user is dead 

    SYNOPSIS
        private void GameManager::GameOverCheck(); 
        
    DESCRIPTION
        This function is responsible for prompting the player 
        with the game over screen if they have died 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/26/2019
    */
/**/
    private void GameOverCheck()
    {
        // for every case, if the player is dead
        // then pause the game and show game over screen
        switch (WaveCount)
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
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
            case 25:
            case 26:
            case 27:
            case 28:
            case 29:
                if (Player.Plyr.IsDead)
                {
                    Pause(m_gameOverPanel);
                }
                
                break;
        }
    }
/* private void GameManager::GameOverCheck(); */

/**/
    /*
    GameManager::ShowMessage GameManager::ShowMessage

    NAME
        GameManager::ShowMessage - shows round prompt

    SYNOPSIS
        IEnumerator GameManager::ShowMessage(); 
        
    DESCRIPTION
        This function is responsible for prompting the player 
        with the current round for a set amount of time before 
        the round starts. 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/26/2019
    */
/**/
    IEnumerator ShowMessage(string a_message)
    {
        // Enables the text
        RoundPromptText.GetComponent<Text>().text = a_message;
        RoundPromptText.GetComponent<Text>().enabled = true;

        // Enables the save feature when the prompt is up
        m_saveButton.interactable = true;
        m_loadButton.interactable = true;

        // Triggers a 7 second delay
        yield return new WaitForSeconds(7);

        // Disables the text and removes from screen
        RoundPromptText.GetComponent<Text>().enabled = false;

        // Disables the ability to save and load until the next prompt
        m_saveButton.interactable = false;
        m_loadButton.interactable = false;
    }
/* IEnumerator GameManager::ShowMessage(string a_message); */
}
