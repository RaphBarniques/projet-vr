using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExempleDetect : MonoBehaviour
{

    public KeyPadControll keypadScript;
    public KeycardReader keycardScript;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keypadScript.accessGranted == true) {
            //Do something
        }

        if (keycardScript.accessGranted == true) {
            //Do something
            animator.Play("ascenseur-porte");
        }
    }
}
