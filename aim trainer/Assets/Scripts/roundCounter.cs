using System.Collections;
using UnityEngine;
using TMPro;
public class roundCounter : MonoBehaviour
{
    public int roundLenght;
    public TextMeshProUGUI CountDown;
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
        while (roundLenght > 0) 
        {
            CountDown.text = roundLenght.ToString();
            yield return new WaitForSeconds(roundLenght);
            roundLenght--;
        }
        EndOfRound();
    }
    private void EndOfRound()
    {

    }

}
