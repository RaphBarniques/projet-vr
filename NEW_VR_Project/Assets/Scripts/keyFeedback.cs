using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyFeedback : MonoBehaviour
{
   
private AudioSource audioSource;
public AudioClip keySound;
public bool keyHit = false;

private Color originalColor;
private Renderer;


private float colorReturnTime = 0.1f;
private float returnColor;


    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1;
        audioSource.volume = 0.1f;
        Renderer = getComponent<Renderer>();
        originalColor = renderer.material.color;



    }

    void Update()
    {
        if (keyHit && returnColor < Time.time){
        audioSource.PlayOneShot(keySound);
        returnColor = Time.time + colorReturnTime;
        renderer.material.color = Color.green;    
        keyHit = false;
        }

        if (renderer.material.color != originalColor && returnColor < Time.time){
            renderer.material.color = originalColor;
        }
    }
}
