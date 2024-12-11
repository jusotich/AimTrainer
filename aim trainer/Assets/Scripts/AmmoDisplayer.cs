using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    public Text ammoText;
    public Gun gun;
    void Start()
    {
        if( ammoText = null)
        {
            ammoText = GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = $"{gun.ammo}/[{gun.ammoMax}";
    }
}
