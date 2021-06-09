using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScreen : MonoBehaviour
{
    public void Start()
    {
        Invoke("Quit", 5);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
