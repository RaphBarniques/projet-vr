using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SafeScript : MonoBehaviour
{

    public KeyPadControll keypadScript;
    public Rigidbody SafeDoor;
    public Rigidbody Keypad;
    public Rigidbody SafeHandle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keypadScript.accessGranted == true) {
            //Do something
            SafeDoor.isKinematic = false;
            Keypad.isKinematic = false;
            SafeHandle.isKinematic = false;
        }
    }
}
