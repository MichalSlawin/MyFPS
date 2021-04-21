using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float MAX_HP = 200;
    private const float START_HP = 100;
    private const float HEALTH_PACK_BONUS = 25;
    private const int AMMO_BOX_BONUS = 2;

    [SerializeField] private float hp = 100;
    [SerializeField] private GrenadeThrower grenadeThrower = null;
    private GameController gameController;

    private void Start()
    {
        UIController.SetHpText(hp);
        gameController = FindObjectOfType<GameController>();
    }

    public void TakeDamage(float damage)
    {
        SetHp(hp -= damage);

        if (hp <= 0)
        {
            gameController.RespawnPlayerRandom(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("HealthPack"))
        {
            AddHealthPackBonus();
            StartCoroutine(other.GetComponent<Collectible>().HideForTime());
        }

        if(other.CompareTag("AmmoBox"))
        {
            AddAmmo();
            StartCoroutine(other.GetComponent<Collectible>().HideForTime());
        }
    }

    private void AddHealthPackBonus()
    {
        SetHp(hp + HEALTH_PACK_BONUS);
    }

    public void SetStartHp()
    {
        SetHp(START_HP);
    }

    private void SetHp(float newHp)
    {
        hp = newHp;
        if (hp > MAX_HP) hp = MAX_HP;
        UIController.SetHpText(hp);
    }

    private void AddAmmo()
    {
        Gun gun = FindObjectOfType<Gun>();

        if(gun != null)
        {
            gun.AddMagazines(AMMO_BOX_BONUS);
        }

        grenadeThrower.AddGrenades(AMMO_BOX_BONUS);
    }

}
