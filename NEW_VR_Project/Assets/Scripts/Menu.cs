using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public Button boutonJouer;
    public Button boutonInstructions;
    public Button boutonQuitter;
    public Button boutonRetour;
    public GameObject PanelMenu;
    public GameObject PanelInstructions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (boutonJouer.isButtonPressed == true){
            SceneManager.LoadScene("Level1Agent");
        }

        if (boutonQuitter.isButtonPressed == true){
            Application.Quit();
        }

        if (boutonInstructions.isButtonPressed == true){
            PanelInstructions.SetActive(true);
            PanelMenu.SetActive(false);
        }

        if (boutonRetour.isButtonPressed == true){
            PanelInstructions.SetActive(false);
            PanelMenu.SetActive(true);
            SceneManager.LoadScene("End");
        }

    }
}
