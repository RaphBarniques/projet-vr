using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadControll : MonoBehaviour
{
    public int correctCombination;
    public bool accessGranted = false;
    public bool useOnce;
    public bool needReset = false;
    public float wait = 5;
    private float timer = 0;
    private float timerEnd;
    private bool timerTriggered;
    private AudioSource audioSource;
    public AudioClip solvedSound;
    public AudioClip failSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1;
        audioSource.volume = 0.1f;
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
                    needReset = true;
                }
            }   
        }
    }

    public bool CheckIfCorrect(int combination) {
        if (combination == correctCombination) {
            accessGranted = true;
            audioSource.PlayOneShot(solvedSound);
            return true;
        }
        audioSource.PlayOneShot(failSound);
        return false;
    }
}