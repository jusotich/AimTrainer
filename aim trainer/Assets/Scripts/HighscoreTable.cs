using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighscoreTable : MonoBehaviour
{
    private Transform enteryContainer;
    private Transform enteryTamplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreenterytransformList;

    private void Awake()
    {
        enteryContainer = transform.Find("HighscoreEntryContainer");
        if (enteryContainer == null) Debug.LogError("HighscoreEntryContainer not found!");

        enteryTamplate = enteryContainer.Find("HighscoreEntryTemplate");
        if (enteryTamplate == null) Debug.LogError("HighscoreEntryTemplate not found!");

        enteryTamplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>()
    {
        new HighscoreEntry{score = 1000, name = "AAA"},
        new HighscoreEntry{score = 1000, name = "BBB"},
        new HighscoreEntry{score = 1000, name = "CCC"},
        new HighscoreEntry{score = 1000, name = "DDD"},
        new HighscoreEntry{score = 1000, name = "EEE"},
        new HighscoreEntry{score = 1000, name = "FFF"},
    };

        highscoreenterytransformList = new List<Transform>();

        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, enteryContainer, highscoreenterytransformList);
        }
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry,Transform container, List<Transform>transformList)
    {
        float templateHight = 30f;
        Debug.Log("loop worked");
        Transform enteryTransform = Instantiate(enteryTamplate, container);
        Debug.Log("enterytrasnform created");

        RectTransform enteryRectTrensform = enteryTransform.GetComponent<RectTransform>();
        Debug.Log("reacttransform created");

        enteryRectTrensform.anchoredPosition = new Vector2(0, -templateHight * transformList.Count);
        Debug.Log("transform anchord");

        enteryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }
        Debug.Log("ranking worked");

        enteryTransform.Find("PlaceText").GetComponent<Text>().text = rankString;
        Debug.Log("place gotten");

        int score = highscoreEntry.score;
        enteryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
        Debug.Log("place gotten");
        
        string name = highscoreEntry.name;
        enteryTransform.Find("NameText").GetComponent<Text>().text = name;
        Debug.Log("place gotten");

        transformList.Add(enteryTransform);
        Debug.Log("entery added to list");

    }
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
