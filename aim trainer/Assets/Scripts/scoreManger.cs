using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class scoreManger : MonoBehaviour
{
    public int currentScore;
    public TextMeshProUGUI score;
    public List<Player> playerList = new List<Player>();
    public void AddScore(int amount)
    {
        currentScore += amount;
    }
    public void AddScoreToList()
    {
        playerList.Add(new Player("test", currentScore));
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
public class Player
{
    public string playerName;
    public int score;

    public Player(string name, int score)
    {
        playerName = name;
        this.score = score;
    }
}
