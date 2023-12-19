using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Changement_Scene : MonoBehaviour
{

        public void Jouer()
        {
            SceneManager.LoadScene("Level1Agent");
        }
    
}
