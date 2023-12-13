using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadControll : MonoBehaviour
{
    public int correctCombination;
    public bool accessGranted = false;
    public bool useOnce;
    public float wait = 5;
    private float timer = 0;
    private float timerEnd;
    private bool timerTriggered;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        timer += Time.deltaTime;
        if (accessGranted == true) {
            if (useOnce != true) {
                if (!timerTriggered){
                    timerTriggered = true;
                    timerEnd = timer + wait;
                } else if (timerTriggered && timerEnd <= timer) {
                    timerTriggered = false;
                    accessGranted = false;
                }
            }   
        }
    }

    public bool CheckIfCorrect(int combination) {
        if (combination == correctCombination) {
            accessGranted = true;
            return true;
        }
        return false;
    }
}