using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunScript : MonoBehaviour
{
    /***************************************************************************************
* Title: Shooting with Raycasts - Unity Tutorial
* Author: Brackeys
* Date: 2017
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=THnivyG0Mvo
***************************************************************************************/
    public GameObject soundManager;
    private SoundManager _soundScript;

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;

    public GameObject impactEffect;
    private void Start()
    {
        _soundScript = soundManager.GetComponent<SoundManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _soundScript.playShootSound();
            FindObjectOfType<AudiosManger>().Play("Gun fire");
            Shoot();    
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        FindObjectOfType<AudiosManger>().Play("Gun fire");
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
