using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Gun gun;

    private void Update()
    {
        textMeshPro.text = gun.ammo.ToString() + "/10";
    }
}
