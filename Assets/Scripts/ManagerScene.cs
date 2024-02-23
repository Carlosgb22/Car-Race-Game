using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    ManagerScene managerScene;
    void Start()
    {
        if (managerScene == null)
        {
            managerScene = this;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("Car Race Game");
    }
    public void Ej1()
    {
        SceneManager.LoadScene("Ej 1");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
