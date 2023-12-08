using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycard : MonoBehaviour
{
  private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
            if (anim != null)
            {
                anim.Play("Base Layer.ascenseur-porte");
            }
    }
}
