using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExempleBouton : MonoBehaviour
{
    
    public Button votreBouton;
    public Canvas projection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (votreBouton.isButtonPressed == true){
            //Do something
            if(other.tag == "slide"){
                projection.setActive(true);
            }
        }

    }
}
