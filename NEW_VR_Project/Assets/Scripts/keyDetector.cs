using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keyDetector : MonoBehaviour
{
   
private TextMeshPro display;

private KeyPadControll keyPadControll;

    void Start()
    {
        display = GameObject.FindGameObjectWithTag("Display").GetComponentInChildren<TextMeshPro>();
        display.text = "";

        keyPadControll = GameObject.FindGameObjectWithTag("Keypad").GetComponent<KeyPadControll>();
    }

private void OnTriggerEnter(Collider other){

if (other.CompareTag("KeypadButton")){

var key = other.GetComponentInChildren<TextMeshPro>();
if (key != null){
    var keyFeedBack = other.gameObject.GetComponent<keyFeedback>();

    if (key.text == "Enter"){
        var accessGranted = false;
        bool onlyNumbers = int.TryParse(display.text, out int value);
        if (onlyNumbers == true && display.text.Length > 0){
            accessGranted = keyPadControll.CheckIfCorrect(Convert.ToInt32(display.text));
        }
if(accessGranted == true){
   display.text = "OK"; 
}else{
    display.text = "Retry";
}
    }
    else if (key.text == "Cancel"){
        display.text = "";
    }else{
        bool onlyNumbers = int.TryParse(display.text, out int value);
        if(onlyNumbers == false){
            display.text = "";
        }

        if(display.text.Length < 4)
        display.text += key.text;
    }
    keyFeedBack.keyHit = true;

            }
        }
    }
}
