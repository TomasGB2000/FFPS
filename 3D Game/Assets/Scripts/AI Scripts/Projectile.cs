using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject soundManager;
    private SoundManager _soundScript;
    /***************************************************************************************
* Title: Follow/Retreat AI
* Author: BlackThornProd
* Date: 2017
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=_Z1t7MNk0c4
***************************************************************************************/

    public float speed;

    public Transform player;
    private Vector3 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector3(player.position.x, player.position.y);

        _soundScript = soundManager.GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
            _soundScript.playShootSound();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            FindObjectOfType<AudiosManger>().Play("Grunt Sound");
            DestroyProjectile();         
        }

        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Pot")
        {
            DestroyProjectile();
        }

        if (other.gameObject.tag == "Crate")
        {
            DestroyProjectile();
        }

        if (other.gameObject.tag == "Wall")
        {
            DestroyProjectile();
        }
        if (other.gameObject.tag == "Ground")
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
