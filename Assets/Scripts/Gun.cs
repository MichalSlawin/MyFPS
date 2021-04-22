using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    private const int MAX_MAGAZINES = 10;

    [SerializeField] private Camera fpsCamera = null;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float fireRate = 15f;
    [SerializeField] private int maxAmmo = 15;
    [SerializeField] private float reloadTime = 1f;
    [SerializeField] private int startMagazines = 5;
    [SerializeField] private ParticleSystem gunShotParticle = null;
    [SerializeField] private ParticleSystem impactEffectPrefab = null;
    [SerializeField] private Animator animator = null;

    private float nextTimeToFire = 0f;
    private AudioSource audioSource;
    private int currentAmmo;
    private int currentMagazines;
    private bool reloading = false;
    private UIController uIController;

    private void OnEnable()
    {
        uIController = FindObjectOfType<UIController>();
        reloading = false;
        animator.SetBool("reloading", false);
        uIController.SetAmmoText(currentAmmo, currentMagazines);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
        currentMagazines = startMagazines;
        uIController.SetAmmoText(currentAmmo, currentMagazines);
    }

    void Update()
    {
        if(currentAmmo <= 0 && !reloading && currentMagazines > 0)
        {
            StartCoroutine(Reload());
        }
        HandleInput();
    }

    public void AddMagazines(int number)
    {
        currentMagazines += number;
        if (currentMagazines > MAX_MAGAZINES) currentMagazines = MAX_MAGAZINES;
        uIController.SetAmmoText(currentAmmo, currentMagazines);
    }

    private IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("reloading", true);
        yield return new WaitForSeconds(reloadTime - 0.5f);
        animator.SetBool("reloading", false);
        yield return new WaitForSeconds(0.25f);
        currentAmmo = maxAmmo;
        currentMagazines--;
        reloading = false;
        uIController.SetAmmoText(currentAmmo, currentMagazines);
    }

    private void HandleInput()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire && !reloading && currentAmmo > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && !reloading && currentAmmo != maxAmmo && currentMagazines > 0)
        {
            StartCoroutine(Reload());
        }
    }

    private void Shoot()
    {
        gunShotParticle.Play();
        RaycastHit hit;

        audioSource.Play();
        currentAmmo--;
        uIController.SetAmmoText(currentAmmo, currentMagazines);

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            if(hit.transform.CompareTag("Enemy"))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if(enemy != null) enemy.TakeDamage(damage);
            }
            if (hit.transform.CompareTag("Player"))
            {
                Player player = hit.transform.GetComponent<Player>();
                if (player != null) player.TakeDamage(damage);
            }
            ParticleSystem particle = Instantiate(impactEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
            particle.Play();
            Destroy(particle.gameObject, 1f);
        }
    }
}
