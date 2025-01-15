using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HighscoreTable : MonoBehaviour
{
    private Transform enteryContainer;
    private Transform enteryTamplate;
    private List<Transform> highscoreenterytransformList;

    private void Awake()
    {
        enteryContainer = transform.Find("HighscoreEntryContainer");
        if (enteryContainer == null) Debug.LogError("HighscoreEntryContainer not found!");

        enteryTamplate = enteryContainer.Find("HighscoreEntryTemplate");
        if (enteryTamplate == null) Debug.LogError("HighscoreEntryTemplate not found!");

        enteryTamplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i+1; j  < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score> highscores.highscoreEntryList[i].score)
                {
                    //swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }  
            }
        }
        highscoreenterytransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, enteryContainer, highscoreenterytransformList);
        }
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry,Transform container, List<Transform>transformList)
    {
        float templateHight = 30f;
        Debug.Log("loop worked");
        Transform enteryTransform = Instantiate(enteryTamplate, container);
        if (enteryTransform == null)
        {
            Debug.LogError("Failed to instantiate HighscoreEntryTemplate!");
            return;
        }

        RectTransform enteryRectTrensform = enteryTransform.GetComponent<RectTransform>();
        enteryRectTrensform.anchoredPosition = new Vector2(0, -templateHight * transformList.Count);
        enteryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "th"; break;
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }
        Debug.Log("ranking worked");

        // Find and set PlaceText
        Transform placeText = enteryTransform.Find("PlaceText");
        if (placeText == null)
        {
            Debug.LogError("PlaceText not found in instantiated template!");
            return;
        }

        TextMeshProUGUI placeTextComponent = placeText.GetComponent<TextMeshProUGUI>();
        if (placeTextComponent == null)
        {
            Debug.LogError("TextMeshProUGUI component missing on PlaceText!");
            return;
        }
        placeTextComponent.text = rankString;


        // Find and set ScoreText
        Transform scoreText = enteryTransform.Find("ScoreText");
        if (scoreText == null)
        {
            Debug.LogError("ScoreText not found in instantiated template!");
            return;
        }

        TextMeshProUGUI scoreTextComponent = scoreText.GetComponent<TextMeshProUGUI>();
        if (scoreTextComponent == null)
        {
            Debug.LogError("TextMeshProUGUI component missing on ScoreText!");
            return;
        }
        scoreTextComponent.text = highscoreEntry.score.ToString();

        // Find and set NameText
        Transform nameText = enteryTransform.Find("NameText");
        if (nameText == null)
        {
            Debug.LogError("NameText not found in instantiated template!");
            return;
        }

        TextMeshProUGUI nameTextComponent = nameText.GetComponent<TextMeshProUGUI>();
        if (nameTextComponent == null)
        {
            Debug.LogError("TextMeshProUGUI component missing on NameText!");
            return;
        }
        nameTextComponent.text = highscoreEntry.name;

        transformList.Add(enteryTransform);
    }


    private void AddHighscoreEntry(int score, string name)
    {
        //creat highscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry {score = score,name = name };

        // load savved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // add new entry yo highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        //save updated highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable",json);
        PlayerPrefs.Save();
    }
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
