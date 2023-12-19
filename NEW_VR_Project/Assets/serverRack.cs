using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class serverRack : MonoBehaviour
{

    private Renderer screen;
    private TextMeshPro displaytText;
    private Button button;
    public Material blueMaterial;
    public Material redMaterial;
    public string rackNumber;
    public bool errorTrigger;
    public bool buttonPressed;
    private AudioSource audioSource;
    public AudioClip keySound;

    // Start is called before the first frame update
    void Start()
    {
        Transform rack = transform.GetChild(0);
        screen = rack.GetChild(0).GetComponent<Renderer>();
        displaytText = rack.GetChild(0).GetChild(0).GetComponent<TextMeshPro>();
        button = rack.GetChild(1).GetComponent<Button>();
        rackNumber = rack.GetChild(2).GetChild(0).GetComponent<TextMeshPro>().text;
    }

    // Update is called once per frame
    void Update()
    {
        if (errorTrigger) {
            displaytText.text = "ERROR";
            screen.material = redMaterial;
        } else {
            displaytText.text = "WORKING";
            screen.material = blueMaterial;
        }

        if (button.isButtonPressed == true && errorTrigger == true) {
            errorTrigger = false;
            buttonPressed = true;
        }
    }

    
}
