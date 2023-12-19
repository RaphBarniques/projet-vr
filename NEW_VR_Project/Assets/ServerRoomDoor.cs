using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ServerRoomDoor : MonoBehaviour
{

    public KeyPadControll KeypadScript;
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
        if (KeypadScript.accessGranted == true && isActive == false)
        {
            animator.Play("ascenseur-porte");
            isActive = true;
        }

        if (KeypadScript.accessGranted == false && isActive == true)
        {
            animator.Play("ascenseur-porte-reverse");
            isActive = false;
        }
    }
}
