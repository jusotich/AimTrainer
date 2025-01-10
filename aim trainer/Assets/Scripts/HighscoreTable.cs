using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LeaderboardManger : MonoBehaviour
{
    private Transform enteryContainer;
    private Transform enteryTamplate;
    private void Awake()
    {
        Debug.Log("awkaup worked.");

        enteryContainer = transform.Find("HighscoreEntryContainer");
        enteryTamplate = enteryContainer.Find("HighscoreEntryTemplate");

        //enteryTamplate.gameObject.SetActive(false);

        
        for (int i = 0; i < 10; i++)
        {

        }
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry,Transform container, List<Transform>transformList)
    {
        float templateHight = 30f;
        //Debug.Log("loop worked");
        Transform enteryTransform = Instantiate(enteryTamplate, container);
        //Debug.Log("enterytrasnform created");

        RectTransform enteryRectTrensform = enteryTransform.GetComponent<RectTransform>();
        //Debug.Log("reacttransform created");

        enteryRectTrensform.anchoredPosition = new Vector2(0, -templateHight * transformList.Count);
        //Debug.Log("transform enchord");

        enteryTransform.gameObject.SetActive(true);

        int rank = i + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }

        enteryTransform.Find("PlaceText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;
        enteryTransform.Find("ScoreText").GetComponent<Text>().text = score;

        string name = highscoreEntry.name;
        enteryTransform.Find("NameText").GetComponent<Text>().text = name;

        transformList.Add(enteryTransform);
    }
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
