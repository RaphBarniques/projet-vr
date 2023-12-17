using UnityEngine;
using TMPro;

public class KeycardReader : MonoBehaviour
{
    // Public variable to store the correct keycard ID
    public int correctKeycardID = 1; // Change this to the correct ID
    public bool accessGranted = false;
    public bool useOnce;
    public float wait = 5;
    private float timer = 0;
    private float timerEnd;
    private bool timerTriggered;
    private TextMeshPro display;
    private AudioSource audioSource;
    public AudioClip solvedSound;
    public AudioClip failSound;

    void Start()
    {   
        display = this.gameObject.transform.GetChild(0).GetComponentInChildren<TextMeshPro>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1;
        audioSource.volume = 0.1f;
    }

    private void OnTriggerEnter(Collider other)
    {   
        // Check if the entering object has the tag "Keycard"
        if (other.CompareTag("Keycard") && accessGranted == false)
        {
            // Access the Keycard script attached to the Keycard object
            Keycard keycard = other.GetComponent<Keycard>();

            // Check if the Keycard script is not null
            if (keycard != null)
            {
                if (keycard.keycardID == correctKeycardID)
                {
                    accessGranted = true;
                    display.text = "OK";
                    audioSource.PlayOneShot(solvedSound);
                }
                else
                {
                    display.text = "Invalid";
                    audioSource.PlayOneShot(failSound);
                }
            }
        }
    }

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
                    display.text = "";
                }
            }   
        }
    }
}
