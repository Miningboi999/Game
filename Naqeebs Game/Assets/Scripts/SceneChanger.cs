using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    [SerializeField] bool isInMainMenu = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isInMainMenu == false)
        {
        SceneManager.LoadScene(0);
        isInMainMenu = true;
        }
    }

    public void PlayGame()
    {
        isInMainMenu = false;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
