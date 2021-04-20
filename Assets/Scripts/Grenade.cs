using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float delay = 3f;
    [SerializeField] private float radius = 10f;
    [SerializeField] private float damage = 100f;
    [SerializeField] private GameObject explosionEffect = null;

    private float countdown;
    private bool exploded = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0 && !exploded)
        {
            Explode();
        }
    }

    private void Explode()
    {
        GameObject effect = Instantiate(explosionEffect, transform.position, transform.rotation);
        exploded = true;

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider collider in colliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if(enemy != null)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                enemy.TakeDamage(damage / (distance + 0.1f));
            }
            Player player = collider.GetComponent<Player>();
            if (player != null)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                player.TakeDamage(damage / (distance + 0.1f));
            }
        }

        Destroy(effect, delay*2);
        Destroy(gameObject);
    }
}
