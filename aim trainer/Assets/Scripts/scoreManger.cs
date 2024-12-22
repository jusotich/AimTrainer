using UnityEngine;
using TMPro;

public class scoreManger : MonoBehaviour
{
    public int currentScore;
    public TextMeshProUGUI score;
    public void AddScore(int amount)
    {
        currentScore += amount;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = currentScore.ToString();
    }
}
