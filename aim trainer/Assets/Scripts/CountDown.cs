using UnityEngine;
using TMPro;
using System.Collections;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public int countdownTime = 3;
    public Gun gun;
    public PlayerMovement playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartCountdown());
    }
    private IEnumerator StartCountdown()
    {
        while (countdownTime > 0)
        {
            gun.canShoot = false;
            playerMovement.canMove = false;
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1);
            countdownTime--;
        }
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1);
        gun.canShoot = true;
        playerMovement.canMove = true;
        countdownText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
