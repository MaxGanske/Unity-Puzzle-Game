using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public int health;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInattackRange;
    public Collider other;
    public int damageToGive = 1;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();



    }

    private void Update()
    {

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInattackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInattackRange) Patroling();
        if (playerInSightRange && !playerInattackRange) ChasePlayer();
        if (playerInattackRange && playerInSightRange) AttackPlayer();


    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;


    }

    public void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2, whatIsGround))
            walkPointSet = true;

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);


    }

    private void AttackPlayer()
    {

        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            if (other.gameObject.tag == "Player")
            {
                Vector3 hitDirection = other.transform.position - transform.position;
                hitDirection = hitDirection.normalized;

                FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);

            }


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }


    }

    private void ResetAttack()
    {
        alreadyAttacked = false;

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Invoke(nameof(DestroyEnemy), .5f);

    }
    private void DestroyEnemy()
    {
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
