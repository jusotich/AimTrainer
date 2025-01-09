using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject leaderboardPanel;
    public void LoadGameScene()
    {
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



