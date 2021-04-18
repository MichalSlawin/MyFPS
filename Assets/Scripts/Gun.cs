using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Camera fpsCamera = null;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float fireRate = 15f;
    [SerializeField] private ParticleSystem gunShotParticle = null;
    [SerializeField] private ParticleSystem impactEffectPrefab = null;

    private float nextTimeToFire = 0f;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        gunShotParticle.Play();
        RaycastHit hit;

        audioSource.Play();

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
