using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private static TextMeshProUGUI ammoText;
    private static TextMeshProUGUI grenadesText;

    private void Start()
    {
        ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        grenadesText = GameObject.Find("GrenadesText").GetComponent<TextMeshProUGUI>();
    }

    public static void SetAmmoText(int ammo, int magazines)
    {
        if(ammoText != null) ammoText.text = ammo.ToString() + " | " + magazines.ToString();
    }

    public static void SetGrenadesText(int number)
    {
        if (grenadesText != null) grenadesText.text = number.ToString();
    }
}
