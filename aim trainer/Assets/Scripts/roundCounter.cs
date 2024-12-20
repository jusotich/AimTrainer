using System.Collections;
using UnityEngine;
using TMPro;

public class roundCounter : MonoBehaviour
{
    public int roundLenght;
    public TextMeshProUGUI roundTimer;
    public CountDown CountDown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RoundCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        
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

        EndOfRound();
    }
    private void EndOfRound()
    {

    }

}
