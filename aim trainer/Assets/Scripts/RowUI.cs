using TMPro;
using UnityEngine;

public class RowUI : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerScoreText;

    public void SetRowData(string playerName, int score)
    {
        playerNameText.text = playerName;
        playerScoreText.text = score.ToString();
    }
}
