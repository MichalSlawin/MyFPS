using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float MAX_HP = 100;
    private const float HEALTH_PACK_BONUS = 25;
    private const int AMMO_BOX_BONUS = 2;

    [SerializeField] private float hp = 100;
    private GrenadeThrower grenadeThrower;

    private void Start()
    {
        UIController.SetHpText(hp);
        grenadeThrower = FindObjectOfType<GrenadeThrower>();
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        UIController.SetHpText(hp);

        if (hp <= 0)
        {
            Debug.Log("You are dead");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("HealthPack"))
        {
            AddHealthPackBonus();
            Destroy(other.gameObject);
        }

        if(other.CompareTag("AmmoBox"))
        {
            AddAmmo();
            Destroy(other.gameObject);
        }
    }

    private void AddHealthPackBonus()
    {
        hp += HEALTH_PACK_BONUS;
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
