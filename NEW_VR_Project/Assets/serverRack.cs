using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class serverRack : MonoBehaviour
{

    private GameObject screen;
    private TextMeshPro displaytText;
    private GameObject button;
    public Material blueMaterial;
    public Material redMaterial;
    public string rackNumber;

    // Start is called before the first frame update
    void Start()
    {
        GameObject rack = this.GameObject.transform.GetChild(0);
        screen = rack.gameObject.transform.GetChild(0);
        displaytText = screen.gameObject.transform.GetChild(0).GetComponent<TextMeshPro>();
        button = rack.gameObject.transform.GetChild(1);
        rackNumber = rack.gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshPro>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
