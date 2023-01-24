using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject soundManager;
    private SoundManager _soundScript;
    /***************************************************************************************
* Title: Shooting with Raycasts - Unity Tutorial
* Author: Brackeys
* Date: 2017
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=THnivyG0Mvo
***************************************************************************************/
    public float health = 50f;
    
    void Start()
    {
        _soundScript = soundManager.GetComponent<SoundManager>();
    }
    

    public void TakeDamage(float amount)
    {
        health -= amount;
        
        if (health <= 0f)
        {   
            Die();      
        }
        _soundScript.playEnemyDeathSound(); 
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
