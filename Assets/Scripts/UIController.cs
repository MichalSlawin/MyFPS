using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private static TextMeshProUGUI ammoText;
    private static TextMeshProUGUI grenadesText;
    private static TextMeshProUGUI hpText;

    private void Start()
    {
        ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        grenadesText = GameObject.Find("GrenadesText").GetComponent<TextMeshProUGUI>();
        hpText = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
    }

    public static void SetAmmoText(int ammo, int magazines)
    {
        if (ammoText == null) ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        if (ammoText != null) ammoText.text = ammo.ToString() + " | " + magazines.ToString();
    }

    public static void SetGrenadesText(int number)
    {
        if (grenadesText == null) grenadesText = GameObject.Find("GrenadesText").GetComponent<TextMeshProUGUI>();
        if (grenadesText != null) grenadesText.text = number.ToString();
    }

    public static void SetHpText(float number)
    {
        if (hpText == null) hpText = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
        if (hpText != null) hpText.text = number.ToString();
    }
}
