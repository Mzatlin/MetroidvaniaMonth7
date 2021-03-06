﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorOnPress : MonoBehaviour
{

    [SerializeField]
    GameObject door;
    [SerializeField]
    LayerMask allowedMasks;
    Animator animator;
    Collider2D doorCollider;

    FMOD.Studio.EventInstance WoodDoorSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = door.GetComponent<Animator>();
        doorCollider = door.GetComponent<Collider2D>();
        WoodDoorSound = FMODUnity.RuntimeManager.CreateInstance("event:/Objects/WoodDoorOpen");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & allowedMasks) != 0)
        {
            animator.SetBool("IsOpen", false);
            doorCollider.enabled = false;
            if (gameObject.name == "WoodDoorSwitch")
            {
                WoodDoorSound.start();

            }
            else
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Door-Open", GetComponent<Transform>().position);

            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & allowedMasks) != 0)
        {
            animator.SetBool("IsOpen", true);
            doorCollider.enabled = true;
            if (gameObject.name == "WoodDoorSwitch")
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/WoodDoorClose", GetComponent<Transform>().position);

            }
            else
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Door-Close", GetComponent<Transform>().position);

            }

        }
    }
}
