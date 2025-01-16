using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class HighscoreTable : MonoBehaviour
{
    public static HighscoreTable Instance;

    [SerializeField] private Transform enteryContainer; // Assigned in Inspector if possible
    [SerializeField] private Transform enteryTamplate;  // Assigned in Inspector if possible

    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreenterytransformList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;

        if (enteryContainer != null && enteryTamplate != null)
        {
            InitializeHighscoreTable();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu") // Only reconnect references in the Main Menu scene
        {
            // Find the Canvas and navigate to the container
            Transform canvasTransform = GameObject.Find("Canvas")?.transform;
            if (canvasTransform == null)
            {
                Debug.LogError("Canvas not found in the Main Menu scene.");
                return;
            }

            Transform leaderboardPanel = canvasTransform.Find("leaderboardPanel");
            if (leaderboardPanel == null)
            {
                Debug.LogError("leaderboardPanel not found under Canvas.");
                return;
            }

            enteryContainer = leaderboardPanel.Find("HighscoreEntryContainer");
            if (enteryContainer == null)
            {
                Debug.LogError("HighscoreEntryContainer not found under leaderboardPanel.");
                return;
            }

            enteryTamplate = enteryContainer.Find("HighscoreEntryTemplate");
            if (enteryTamplate == null)
            {
                Debug.LogError("HighscoreEntryTemplate not found under HighscoreEntryContainer.");
                return;
            }

            InitializeHighscoreTable();
        }
    }

    private void InitializeHighscoreTable()
    {
        enteryTamplate.gameObject.SetActive(false);
        highscoreEntryList = new List<HighscoreEntry>();

        // Load highscores from PlayerPrefs
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores != null)
        {
            highscoreenterytransformList = new List<Transform>();
            foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
            {
                CreateHighscoreEntryTransform(highscoreEntry, enteryContainer, highscoreenterytransformList);
            }
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHight = 30f;
        Transform enteryTransform = Instantiate(enteryTamplate, container);
        RectTransform enteryRectTransform = enteryTransform.GetComponent<RectTransform>();
        enteryRectTransform.anchoredPosition = new Vector2(0, -templateHight * transformList.Count);
        enteryTransform.gameObject.SetActive(true);

        // Assign rank, score, and name
        enteryTransform.Find("PlaceText").GetComponent<TextMeshProUGUI>().text = $"{transformList.Count + 1}";
        enteryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = highscoreEntry.score.ToString();
        enteryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = highscoreEntry.name;

        transformList.Add(enteryTransform);
    }

    public void AddHighscoreEntry(int score, string name)
    {
        // Create new entry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Load saved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString) ?? new Highscores { highscoreEntryList = new List<HighscoreEntry>() };

        // Add new entry and save
        highscores.highscoreEntryList.Add(highscoreEntry);
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    [System.Serializable]
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}