using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    /***************************************************************************************
* Title: Events
* Author: Game Dev Guide
* Date: 2019
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=gx0Lt4tCDE0
***************************************************************************************/

    private void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
    }

    private void OnDoorwayOpen()
    {
        Destroy(gameObject);
    }
}
