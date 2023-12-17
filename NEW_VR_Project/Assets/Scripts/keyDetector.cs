using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keyDetector : MonoBehaviour
{
   
private TextMeshPro display;

private KeyPadControll keyPadControll;

private bool keydown;

    void Start()
    {

    }

private void OnTriggerEnter(Collider other){

    keyPadControll = other.transform.parent.gameObject.GetComponent<KeyPadControll>();
    display = other.transform.parent.gameObject.transform.GetChild(0).GetComponentInChildren<TextMeshPro>();

if (other.CompareTag("KeypadButton") && keyPadControll.accessGranted != true && keydown == false){

var key = other.GetComponentInChildren<TextMeshPro>();
    if (key != null){
        var keyFeedBack = other.gameObject.GetComponent<keyFeedback>();

        if (key.text == "Enter"){
            var accessGranted = false;
            bool onlyNumbers = int.TryParse(display.text, out int value);

            if (onlyNumbers == true && display.text.Length > 0){
                accessGranted = keyPadControll.CheckIfCorrect(Convert.ToInt32(display.text), display);
            }

            if(accessGranted == true){
                //display.fontSize = 8.5f;
                display.text = "OK"; 
            }else{
                //display.fontSize = 8.5f;
                display.text = "Retry";
            }

        } else if (key.text == "Cancel"){
            display.text = "";
            
        } else{
            bool onlyNumbers = int.TryParse(display.text, out int value);
            if(onlyNumbers == false){
                display.text = "";
            }

            if(display.text.Length < 4)
            //display.fontSize = 6.7f;
            display.text += key.text;
        }
                keyFeedBack.keyHit = true;
                keydown = true;

            }
        }
    }

    private void OnTriggerExit(Collider other){
            keydown = false;
        }

}

