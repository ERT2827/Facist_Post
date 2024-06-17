using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;

    public void QuitGame()
    {
	    Application.Quit();
    }
    public void ResetGame()
    {
	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenMenu()
    {
        if (Input.GetButtonDown("Cancel") && mainMenu.activeSelf == false)
        {
            mainMenu.SetActive(true);
            Debug.Log("pause");
        }else if (Input.GetButtonDown("Cancel") && mainMenu.activeSelf == true)
        {
            mainMenu.SetActive(false);
        }
    }

    private void Update()
    {
        if (globalVariables.UI_Open == false)
        {
            OpenMenu();
        }

    }
}
