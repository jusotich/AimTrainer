using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class scoreManger : MonoBehaviour
{
    public int currentScore;
    public TextMeshProUGUI score;

    public void AddScore(int amount)
    {
        currentScore += amount;
        score.text = currentScore.ToString();
    }
}
