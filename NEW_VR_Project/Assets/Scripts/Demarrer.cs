using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class menuControl : MonoBehaviour
{
   
    public void jouer()
    {
        SceneManager.LoadScene("Level1Agent");
    }
}

public void quitterPartie()
    {
        Application.Quit();
    }
