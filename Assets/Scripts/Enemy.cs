using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float hp = 100;

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
