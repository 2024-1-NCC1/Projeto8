using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    public void BackToMenu(string cena1)
    {
        SceneManager.LoadScene(cena1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}


