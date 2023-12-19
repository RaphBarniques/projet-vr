using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PorteBureau : MonoBehaviour
{

    public KeycardReader keycardScript;
    public Animator animator;
    private bool isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator.Play("porte-bureau-reverse");
    }

    // Update is called once per frame
    void Update()
    {
        if (keycardScript.accessGranted == true && isActive == false) {
            animator.Play("porte-bureau");
            isActive = true;
        }

        if (keycardScript.accessGranted == false && isActive == true) {
            animator.Play("porte-bureau-reverse");
            isActive = false;
        }
    }
}
