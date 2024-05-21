using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public UIScript ui;
    AttackingScript attackingScript;

    public NPCInteractable npc1;
    public NPCInteractable2 npc2;

    public float baseDamage = 20f;
    public float damage;

    Animator anim;
    public int health;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();

        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        // get attacking script
        attackingScript = GetComponent<AttackingScript>();

    }

    // Update is called once per frame
    void Update()
    {

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

        damage = baseDamage * ui.damageMultiplier;
    }

    public void takeDamage()
    {
        health -= (int)damage;
        print("Enemy Killed");
        if(health <= 0)
        {
            if (GameObject.FindGameObjectWithTag("Boss1"))
            {
                npc1.quest1 = false;
                npc1.quest1Complete = true;
                ui.coins += 30;
            }
            if (GameObject.FindGameObjectWithTag("Boss2"))
            {
                npc2.quest2 = false;
                npc2.quest2Complete = true;
                ui.coins += 30;
            }
            Invoke(nameof(Die), 0.1f);
            ui.coins += 10;
            
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        anim.SetBool("OgreAttack", false);
        anim.SetBool("OrcAttack", false);

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        anim.SetBool("OgreAttack", false);
        anim.SetBool("OrcAttack", false);
    }

    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //attackcode
            ui.TakeDamage(20);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        anim.SetBool("OgreAttack", true);
        anim.SetBool("OrcAttack", true);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
