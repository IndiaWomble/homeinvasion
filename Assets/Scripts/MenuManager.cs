using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ChangeToGameplay()
    {
        SceneManager.LoadScene("demo");
    }

    public void ExitGame()
    {
        Application.Quit();
    }   
}
