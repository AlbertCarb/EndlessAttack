using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_mainMenuPanel; // reference to the main menu screen 

/**/
    /*
    MainMenuManager::Play() MainMenuManager::Play()

    NAME
        MainMenuManager::Play - starts the game

    SYNOPSIS
        public void MainMenuManager::Play(); 
       
    DESCRIPTION
        This function is responsible for changing the scene from the main
        menu to the game

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/27/2019
    */
/**/
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
/* public void MainMenuManager::Play(); */

/**/
    /*
    MainMenuManager::Quit() MainMenuManager::Quit()

    NAME
        MainMenuManager::Quit - quits the game

    SYNOPSIS
        public void MainMenuManager::Quit(); 
       
    DESCRIPTION
        This function is responsible for closing the application

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        8/27/2019
    */
/**/
    public void Quit()
    {
        Application.Quit();
    }
/* public void MainMenuManager::Quit(); */
}
