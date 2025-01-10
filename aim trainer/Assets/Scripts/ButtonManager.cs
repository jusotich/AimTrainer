using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject leaderboardPanel;
    [SerializeField] private GameObject inputNameField;
    public void LoadGameScene()
    {
        inputNameField.gameObject.SetActive(true);
        leaderboardPanel.SetActive(false);

        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenSettings()
    {

    }
    public void OpenLeaderboard()
    {
        leaderboardPanel.SetActive(!leaderboardPanel.activeSelf);
    }
}   



