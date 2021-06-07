using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    public void PlayGame2()
    {
        SceneManager.LoadScene(2);

    }
    public void MainMenu2()
    {
        SceneManager.LoadScene(0);
    }
}
