using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    //Move to string scene
    public void moveToScene(string scene)
    {
        //Change the scene
        SceneManager.LoadScene(scene);
    }

    //finalization the aplication
    public void aplicationExit()
    {
        Application.Quit();
    }
}
