using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] // this allows the entire class to be serialized 
public class GameSaveData
{
    public int m_currentRound; // saves the current round being played
    public string m_roundPromptText; // saves the prompt text for the current round 
    public bool m_gamePause; // saves the current state if the game was paused or not before saving
    public bool m_Prompt; // saves the current state of the round prompt
    public bool m_upgraded; // saves the current state if the player has been upgraded 

/**/
    /*
    GameManager::GameSaveData() GameManager::GameSaveData()

    NAME
        GameManager::GameSaveData - initializes the GameManager class objects

    SYNOPSIS
        public GameManager::GameSaveData(GameManager a_gManager); 
            a_gManager -> the reference to the game manager being saved
       
    DESCRIPTION
        This function is responsible for acting as a constructor for the GameManager
        class objects. These variables will be referenced when saving the GameManager
        data to our save file.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/3/2019
    */
/**/   
    public GameSaveData(GameManager a_gManager)
    {
        m_currentRound = a_gManager.WaveCount;
        m_roundPromptText = a_gManager.RoundPromptText.GetComponent<Text>().text;
        m_gamePause = a_gManager.m_isGamePaused;
        m_Prompt = a_gManager.m_wasPrompted;
        m_upgraded = a_gManager.IsUpgraded;
    }
/* public GameManager::GameSaveData(GameManager a_gManager); */
}
