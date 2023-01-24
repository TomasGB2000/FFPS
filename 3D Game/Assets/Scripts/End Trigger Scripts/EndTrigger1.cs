using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger1 : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject soundManager;
    private SoundManager _soundScript;

    void Start()
    {
        _soundScript = soundManager.GetComponent<SoundManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level 3");
            _soundScript.playWinSound();
        }
    }
}

