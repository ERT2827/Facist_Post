using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public bool mainMenu;

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
        if (Input.GetButton("Cancel"))
        {
            gameObject.SetActive(true);
        }
    }


}
