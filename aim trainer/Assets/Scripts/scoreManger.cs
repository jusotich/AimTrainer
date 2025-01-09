using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class scoreManger : MonoBehaviour
{
    public int currentScore;
    public TextMeshProUGUI score;
    public List<Player> playerList = new List<Player>();

    public GameObject rowPreFab;
    public Transform leaderboardContent;

    public void AddScore(int amount)
    {
        currentScore += amount;
        score.text = currentScore.ToString();
    }
    public void AddScoreToList(string playerName)
    {
        playerList.Add(new Player(playerName, currentScore));
        currentScore = 0;
        UpdateLeaderboard();
    }
    public void UpdateLeaderboard()
    {
        foreach (Transform child in leaderboardContent)
        {
            Destroy(child.gameObject);
        }

        playerList.Sort((x,y) =>y.score.CompareTo(x.score));

        foreach (Player player in playerList)
        {
            GameObject row = Instantiate(rowPreFab, leaderboardContent);
            TextMeshProUGUI[] texts = row.GetComponentsInChildren<TextMeshProUGUI>();

            // Assuming the first text is the player's name and the second is the score:
            texts[0].text = player.playerName;
            texts[1].text = player.score.ToString();
        }
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
