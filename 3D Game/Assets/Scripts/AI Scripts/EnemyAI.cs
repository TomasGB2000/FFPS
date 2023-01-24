using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public GameObject soundManager;
    private SoundManager _soundScript;
    /***************************************************************************************
* Title: FULL 3D ENEMY AI in 6 MINUTES! || Unity Tutorial
* Author: Dave / GameDevelopment
* Date: 2020
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=UjkSFoLxesw&list=WL&index=26&t=7s
***************************************************************************************/
    public NavMeshAgent agent;

    public Transform player;


    public LayerMask whatIsGround, whatIsPlayer , whatIsDoor , whatIsWall;

    public float health;

    private Animator enemyAnim;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    void Start()
    {
        _soundScript = soundManager.GetComponent<SoundManager>();
    }
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        enemyAnim.SetBool("isRunning", true);

        if (walkPointSet)
            agent.SetDestination(walkPoint);
        enemyAnim.SetBool("isRunning", true);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
        enemyAnim.SetBool("isRunning", false);
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
        enemyAnim.SetBool("isRunning", true);
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        enemyAnim.SetBool("isRunning", true);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            enemyAnim.SetBool("isAttacking", true);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            enemyAnim.SetBool("isAttacking", false);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
        enemyAnim.SetBool("isAttacking", false);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        _soundScript.playShootSound();
        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        FindObjectOfType<AudiosManger>().Play("Enemy Death");
        _soundScript.playEnemyDeathSound();
        enemyAnim.SetBool("isDead", true);
        Destroy(gameObject);   
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}