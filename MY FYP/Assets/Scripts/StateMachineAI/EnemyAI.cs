using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;
    

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject Projectile;

    public Transform firePoint;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Image healthBar;
    public GameObject healthBarCanvas;
    public float maxHealth = 100f;

    private bool isDead = false;

    private GameManager gameManager;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        health = maxHealth;
        healthBarCanvas.SetActive(false);

        gameManager = FindFirstObjectByType<GameManager>();

    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
        
        if (healthBarCanvas.activeSelf)
        {
            healthBarCanvas.transform.LookAt(player);
        }

    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
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

            GameObject bullet = Instantiate(Projectile, firePoint.position, transform.rotation);

            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
            
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            Vector3 targetPos = player.position + Vector3.up * 1f;
            Vector3 attackDirection = (targetPos - firePoint.position).normalized;

            rb.AddForce(attackDirection.normalized * 32f, ForceMode.Impulse);

            Destroy(bullet, 3f);

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
        if (isDead) return;

        health -= damage;
        healthBarCanvas.SetActive(true);
        healthBar.fillAmount = health / maxHealth;

        if (health <= 0)
        {
            isDead = true;
            DestroyEnemy();
        }



    }

    private void DestroyEnemy()
    {
        gameManager.EnemyKilled();
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