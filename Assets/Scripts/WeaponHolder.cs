using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private int selectedWeapon = 0;

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        HandleInput();
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    private void HandleInput()
    {
        int previousWeapon = selectedWeapon;

        float wheelValue = Input.GetAxis("Mouse ScrollWheel");
        if (wheelValue > 0)
        {
            selectedWeapon = (selectedWeapon + 1) % transform.childCount;
        }
        else if(wheelValue < 0)
        {
            if (selectedWeapon == 0) selectedWeapon = transform.childCount;
            selectedWeapon = (selectedWeapon - 1) % transform.childCount;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedWeapon = 2;
        }

        if (previousWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }
}
