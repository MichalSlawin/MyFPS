using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float hp = 10;

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
