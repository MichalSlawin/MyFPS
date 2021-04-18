using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Camera fpsCamera = null;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private ParticleSystem gunShotParticle = null;
    [SerializeField] private ParticleSystem impactEffectPrefab = null;

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        gunShotParticle.Play();
        RaycastHit hit;

        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            if(hit.transform.CompareTag("Enemy"))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if(enemy != null) enemy.TakeDamage(damage);
            }
            ParticleSystem particle = Instantiate(impactEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(particle.gameObject, 1f);
        }
    }
}
