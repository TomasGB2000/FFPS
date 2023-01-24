using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject soundManager;
    private SoundManager _soundScript;
    public GameObject gameManger;
    private GameManager _gameManager;

    public static bool playerIsDead = false;
    public GameObject gameOver;

    public float speed = 50f;

    Rigidbody playerBody;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    public void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _soundScript = soundManager.GetComponent<SoundManager>();
    }

    // Update is called once per frame
    public void Update()
    {
        UserInput();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            Destroy(playerBody.gameObject);
            FindObjectOfType<GameManager>().EndGame();      
            gameOver.SetActive(true);
        }

    }

    public void UserInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        //conditions upon player collision

        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
            _soundScript.playGruntSound();
            FindObjectOfType<AudiosManger>().Play("Grunt Sound");
        }

        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(20);
            _soundScript.playGruntSound();
            FindObjectOfType<AudiosManger>().Play("Grunt Sound");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            _soundScript.playKeySound();
        }
    }
}