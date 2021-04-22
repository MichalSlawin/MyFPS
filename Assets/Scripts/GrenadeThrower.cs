using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GrenadeThrower : NetworkBehaviour
{
    private const int MAX_GRENADES = 5;

    [SerializeField] private float throwForce = 20f;
    [SerializeField] private GameObject grenadePrefab = null;
    [SerializeField] private int currentGrenades = 2;

    private Camera playerCamera;
    private UIController uIController;

    private void Start()
    {
        playerCamera = GetComponent<Camera>();
        uIController = FindObjectOfType<UIController>();
        uIController.SetGrenadesText(currentGrenades);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(currentGrenades > 0) ThrowGrenade();
        }
    }

    public void AddGrenades(int number)
    {
        currentGrenades += number;
        if (currentGrenades > MAX_GRENADES) currentGrenades = MAX_GRENADES;
        SetGrenadesText();
    }

    private void SetGrenadesText()
    {
        if(uIController == null) uIController = FindObjectOfType<UIController>();
        uIController.SetGrenadesText(currentGrenades);
    }

    private void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, playerCamera.transform.position, playerCamera.transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(playerCamera.transform.forward * throwForce, ForceMode.VelocityChange);
        currentGrenades--;
        SetGrenadesText();
    }
}
