using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorController : MonoBehaviour
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
    private Animator doorAnim;
    private bool doorOpen = false;

    [Header("Animation Names")]
    [SerializeField] private string openAnimationName = "DoorOpen";
    [SerializeField] private string closeAnimationName = "DoorClose";
    [SerializeField] private KeyInventory _keyInventory = null;

    [SerializeField] private int timeToShowUI = 1;
    [SerializeField] private GameObject showDoorUnlockedUI = null;

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    void Start()
    {
        _soundScript = soundManager.GetComponent<SoundManager>();
    }
    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    public void PlayAnimation()
    {
        if (_keyInventory.hasRoomKey)
        {
            OpenDoor();
            _soundScript.playShootSound();
        }
        

        else if (_keyInventory.hasHallwayKey)
        {
            OpenDoor();
            _soundScript.playShootSound();
        }
        

        else if (_keyInventory.hasLoungeKey)
        {
            OpenDoor();
            _soundScript.playShootSound();
        }
        

        else if (_keyInventory.hasGunKey)
        {
            OpenDoor();
            _soundScript.playShootSound();
        }

        else
        {
            StartCoroutine(showDoorLocked());
        }

        void OpenDoor()
        {
            if (!doorOpen && !pauseInteraction)
            {
                doorAnim.Play(openAnimationName, 0, 0.0f);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
                _soundScript.playShootSound();
            }

            else if (!doorOpen && !pauseInteraction)
            {
                doorAnim.Play(openAnimationName, 0, 0.0f);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
                _soundScript.playShootSound();
            }
        }

        IEnumerator showDoorLocked()
        {
            showDoorUnlockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorUnlockedUI.SetActive(false);
        }
    }

    
}
