using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenAuthor()
    {
        Debug.Log("Created by CindyV-149251970100-178");
    }

    public void BacktoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenCredit()
    {        
        SceneManager.LoadScene("Credit");
    }
}
