using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    private const int MAX_GRENADES = 5;

    [SerializeField] private float throwForce = 20f;
    [SerializeField] private GameObject grenadePrefab = null;
    [SerializeField] private int currentGrenades = 2;

    private Camera playerCamera;

    private void Start()
    {
        playerCamera = GetComponent<Camera>();
        UIController.SetGrenadesText(currentGrenades);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(currentGrenades > 0) ThrowGrenade();
        }
    }

    private void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, playerCamera.transform.position, playerCamera.transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(playerCamera.transform.forward * throwForce, ForceMode.VelocityChange);
        currentGrenades--;
        UIController.SetGrenadesText(currentGrenades);
    }
}
