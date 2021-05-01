using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private float SPEED_MULTIPLIER = 1.5f;

    private const float DAMAGE = 10;
    private const float DAMAGE_DISTANCE = 1.5f;

    [SerializeField] private float hp = 100;
    private NavMeshAgent navMeshAgent;
    private Player player;
    private bool dealtDamage = false;
    private static bool speedIncreased = false;

    public static bool SpeedIncreased { get => speedIncreased; set => speedIncreased = value; }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
        GameController.ActiveEnemies++;

        if(SpeedIncreased)
        {
            navMeshAgent.speed *= SPEED_MULTIPLIER;
            navMeshAgent.angularSpeed *= SPEED_MULTIPLIER;
            navMeshAgent.acceleration *= SPEED_MULTIPLIER;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            navMeshAgent.SetDestination(player.transform.position);
            if (Vector3.Distance(transform.position, player.transform.position) <= DAMAGE_DISTANCE)
            {
                DealDamage(player);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }
    }

    public void DealDamage(Player player)
    {
        if(!dealtDamage)
        {
            player.TakeDamage(DAMAGE);
            Die();
        }
    }

    private void Die()
    {
        GameController.IncreaseKillCount();
        GameController.ActiveEnemies--;
        Destroy(gameObject);
    }

}
