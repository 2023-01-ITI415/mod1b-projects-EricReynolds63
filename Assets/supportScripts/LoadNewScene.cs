using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{

    public void LoadScene1()
    {
        SceneManager.LoadScene("_Scene_0");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Main-MissionDemolition");
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene("Main-Prototype 1");
    }

    

}
