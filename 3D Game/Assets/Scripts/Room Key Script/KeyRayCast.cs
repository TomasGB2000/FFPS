using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyRayCast : MonoBehaviour
{
    public GameObject soundManager;
    private SoundManager _soundScript;

    /***************************************************************************************
* Title: OPENING a DOOR in UNITY with a KEY!
* Author: SpeedTutor
* Date: 2021
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=SlEgvvNYXQU
***************************************************************************************/
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string exclusiveLayerName = null;

    private KeyItemController raycastedObject;
    [SerializeField] private KeyCode openDoorKey = KeyCode.Space;

    [SerializeField] private Image crosshair = null;
    private bool isCrossHairActive;
    private bool doOnce;

    private string interactableTag = "InteractiveObject";

    void Start()
    {
        _soundScript = soundManager.GetComponent<SoundManager>();
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(exclusiveLayerName) | layerMaskInteract.value;
        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                    CrossHairChange(true);
                    //_soundScript.playKeyPickUpSound();
                }

                isCrossHairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    raycastedObject.ObjectInteraction();
                    FindObjectOfType<AudiosManger>().Play("Door Open");
                    _soundScript.playKeyPickUpSound();
                }
            }
        }
        else
        {
            if (isCrossHairActive)
            {
                CrossHairChange(false);
                doOnce = false;
            }
        }
    }

    void CrossHairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrossHairActive = false;
        }
    }

}
