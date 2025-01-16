using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class roundCounter : MonoBehaviour
{
    public int roundLenght;
    public TextMeshProUGUI roundTimer;
    public CountDown CountDown;
    public scoreManger scoreManger;
    public Gun Gun;
    public PlayerMovement PlayerMovement;
    public string playerName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RoundCountdown());
    }
    private IEnumerator RoundCountdown()
    {
        yield return new WaitForSeconds(CountDown.countdownTime);
        while (roundLenght > 0)
        {
            roundTimer.text = roundLenght.ToString();
            yield return new WaitForSeconds(1);
            roundLenght--;
        }

        roundTimer.text = "0";
        yield return new WaitForSeconds(1);

        PlayerMovement.canMove = false;
        Gun.canShoot = false;
        CountDown.countdownText.text = "finsish";
        CountDown.countdownText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
}