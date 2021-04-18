using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private static TextMeshProUGUI ammoText;

    private void Start()
    {
        ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
    }

    public static void SetAmmoText(int ammo, int magazines)
    {
        ammoText.text = ammo.ToString() + " | " + magazines.ToString();
    }
}
