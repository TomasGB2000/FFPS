using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemController : MonoBehaviour
{
    /***************************************************************************************
* Title: OPENING a DOOR in UNITY with a KEY!
* Author: SpeedTutor
* Date: 2021
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=SlEgvvNYXQU
***************************************************************************************/
    [SerializeField] private bool roomDoor = false;
    [SerializeField] private bool roomKey = false;
    [SerializeField] private bool hallwayDoor = false;
    [SerializeField] private bool hallwayKey = false;
    [SerializeField] private bool loungeDoor = false;
    [SerializeField] private bool loungeKey = false;
    [SerializeField] private bool gunDoor = false;
    [SerializeField] private bool gunKey = false;

    [SerializeField] private KeyInventory _keyInventory = null;

    private KeyDoorController doorObject;

    private void Start()
    {
        if (roomDoor)
        {
            doorObject = GetComponent<KeyDoorController>();
        }

        if (hallwayDoor)
        {
            doorObject = GetComponent<KeyDoorController>();
        }

        if (loungeDoor)
        {
            doorObject = GetComponent<KeyDoorController>();
        }

        if (gunDoor)
        {
            doorObject = GetComponent<KeyDoorController>();
        }
    }

    public void ObjectInteraction()
    {
        if (roomDoor)
        {
            doorObject.PlayAnimation();
        }
        else if (roomKey)
        {
            _keyInventory.hasRoomKey = true;
            gameObject.SetActive(false);
        }
        if (hallwayDoor)
        {
            doorObject.PlayAnimation();
        }
        else if (hallwayKey)
        {
            _keyInventory.hasHallwayKey = true;
            gameObject.SetActive(false);
        }
        if (loungeDoor)
        {
            doorObject.PlayAnimation();
        }
        else if (loungeKey)
        {
            _keyInventory.hasLoungeKey = true;
            gameObject.SetActive(false);
        }
        if (gunDoor)
        {
            doorObject.PlayAnimation();
        }
        else if (gunKey)
        {
            _keyInventory.hasGunKey = true;
            gameObject.SetActive(false);
        }
    }
}
