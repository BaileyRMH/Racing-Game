using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonScript : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    { 
        Application.Quit();
    }




}
