using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExempleDetect : MonoBehaviour
{

    public KeycardReader keycardScript;
    public Animator animator;
    private bool isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator.Play("ascenseur-porte-reverse");
    }

    // Update is called once per frame
    void Update()
    {
        if (keycardScript.accessGranted == true) {
            animator.Play("ascenseur-porte");
        }

        if (keycardScript.accessGranted == true) {
            //Do something
        }
    }
}
