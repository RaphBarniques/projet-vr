using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote : MonoBehaviour
{
    
    public Button boutonPlus;
    public Button boutonMoins;
    public GameObject slide1;
    public GameObject slide2;
    public GameObject slide3;
    private bool pressed = false;
    private int id = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boutonPlus.isButtonPressed == true && pressed == false && id < 4){
            pressed = true;
            id++;
        } else if (boutonPlus.isButtonPressed == false && pressed == true){
            pressed = false;
        }

        if (boutonMoins.isButtonPressed == true && pressed == false && id > 0){
            pressed = true;
            id--;
        } else if (boutonMoins.isButtonPressed == false && pressed == true){
            pressed = false;
        }


        switch (id)
        {
        case 1:
            slide1.SetActive(true);
            slide2.SetActive(false);
            slide3.SetActive(false);
            break;
        case 2:
            slide1.SetActive(false);
            slide2.SetActive(true);
            slide3.SetActive(false);
            break;
        case 3:
            slide1.SetActive(false);
            slide2.SetActive(false);
            slide3.SetActive(true);
            break;
        }
    }
}
