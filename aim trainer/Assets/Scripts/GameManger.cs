using UnityEngine;
using TMPro;
using UnityEditor;

public class scoreManger : MonoBehaviour
{
    public InputHandler InputHandler;
    public HighscoreTable HighscoreTable;
    public static scoreManger Instance; // Singleton instance
    public int currentScore; // The score value

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep it across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
    }

    public void SaveEvent()
    {
        // Check if this is the second or subsequent time loading the Main Menu
        if (IsFirstTimeEnteringMainMenu())
        {
            Debug.Log("First time in Main Menu, not saving score.");
            return; // Don't save the score the first time
        }

        if (HighscoreTable.Instance != null)
        {
            Debug.Log("Saving score...");
            HighscoreTable.Instance.AddHighscoreEntry(currentScore, InputHandler.playerName);
        }
        else
        {
            Debug.LogError("Cannot save score: HighscoreTable instance is missing!");
        }
    }

    private bool IsFirstTimeEnteringMainMenu()
    {
        // Check PlayerPrefs for flag
        if (PlayerPrefs.HasKey("HasEnteredMainMenu"))
        {
            // If flag exists, this is not the first time
            return false;
        }
        else
        {
            // If flag doesn't exist, this is the first time, so set it
            PlayerPrefs.SetInt("HasEnteredMainMenu", 1);
            PlayerPrefs.Save();
            return true;
        }
    }
}

