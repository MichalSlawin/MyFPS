using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private const float DAMAGE = 10;
    private const float DAMAGE_DISTANCE = 1.5f;

    [SerializeField] private float hp = 100;
    private NavMeshAgent navMeshAgent;
    private Player player;
    private bool dealtDamage = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
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
            Destroy(gameObject);
        }
    }

    public void DealDamage(Player player)
    {
        if(!dealtDamage)
        {
            player.TakeDamage(DAMAGE);
            Destroy(gameObject);
        }
    }

}
