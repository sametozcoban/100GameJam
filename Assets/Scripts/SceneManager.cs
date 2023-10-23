using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    Scene scene;
    private int activeScene;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Haydar"))
        {
            activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            UnityEngine.SceneManagement.SceneManager.LoadScene(activeScene + 1);
            if (activeScene >4)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            }
        }
        else if (collision.CompareTag("Player"))
        {
            activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            UnityEngine.SceneManagement.SceneManager.LoadScene(activeScene + 1);
            if (activeScene >4)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            }
        }

    }
}
