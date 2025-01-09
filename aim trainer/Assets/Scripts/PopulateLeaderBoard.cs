using System.Collections.Generic;
using UnityEngine;

public class PopulateLeaderBoard : MonoBehaviour
{
    public GameObject rowPrefab; // Assign a prefab for leaderboard rows
    public Transform content; // Drag a Content container from your Panel

    public void PopulateLeaderboard(List<Player> players)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject); // Clear previous rows
        }

        foreach (var player in players)
        {
            GameObject row = Instantiate(rowPrefab, content);
            row.GetComponent<RowUI>().SetRowData(player.playerName, player.score);
        }
    }
}
