using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class navigation : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToGame()
    {
        SceneManager.LoadScene("GCTest");
    }
    public void GoToCredits() 
    {

    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GoToTutorial()
    {

    }
}
