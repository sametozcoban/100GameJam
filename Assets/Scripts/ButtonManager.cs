using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject [] playerPos;
    public GameObject gameOverMenu;
    public Health _health;

    Scene scene;
   
   
    public GameObject ui;

    private int activeSceneIndex;
    public void playGame()
    {
        //SceneManager.LoadScene(1);
      //  SceneManager.LoadScene(1);
       // SceneManager.LoadScene(1);
       // SceneManager.LoadScene(1);
        //SceneManager.LoadScene(1);
      //  SceneManager.LoadScene(1);
       // SceneManager.LoadScene(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene1");
    } 
    
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("cikti");
    }
    
    public void options()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
        
    } 
    
    public void ReturntoMainMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        
    }

    public void RestartGame()
    {
        if(scene.name == "Scene1")
        {
            GameObject.FindGameObjectWithTag("Haydar").transform.position= playerPos[1].transform.position;

          // if (_health.currentHealth )
          // {
          //     gameOverMenu.SetActive(true);
          // }
          // else
          // {
          //     gameOverMenu.SetActive(false);
          // }
        }
    }
    public void Rest()
    {
        activeSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(activeSceneIndex);
        ui.SetActive(false);
        
    }

    public void ReturnMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

}
