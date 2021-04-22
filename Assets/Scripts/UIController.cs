using UnityEngine;
using TMPro;
using Mirror;

public class UIController : NetworkBehaviour
{
    private TextMeshProUGUI ammoText;
    private TextMeshProUGUI grenadesText;
    private TextMeshProUGUI hpText;

    private void Start()
    {
        ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        grenadesText = GameObject.Find("GrenadesText").GetComponent<TextMeshProUGUI>();
        hpText = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
    }

    public void SetAmmoText(int ammo, int magazines)
    {
        if (ammoText == null) ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        if (ammoText != null) ammoText.text = ammo.ToString() + " | " + magazines.ToString();
    }

    public void SetGrenadesText(int number)
    {
        if (grenadesText == null) grenadesText = GameObject.Find("GrenadesText").GetComponent<TextMeshProUGUI>();
        if (grenadesText != null) grenadesText.text = number.ToString();
    }

    public void SetHpText(float number)
    {
        if (hpText == null) hpText = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
        if (hpText != null) hpText.text = Mathf.Ceil(number).ToString();
    }
}
