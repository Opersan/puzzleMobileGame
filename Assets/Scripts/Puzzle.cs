using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameEvents;

public class Puzzle : MonoBehaviour
{
    public int answer = 5;
    public TMP_InputField input;
    public Image backgroundImage;
    public Image storyBackgroundImage;
    public Text storyTextElement;
    public string storyText;

    void Start()
    {
        List<PuzzleData.PuzzleStoryData> puzzleData = PuzzleData.ins.puzzleStory_data;
        setPuzzleData(puzzleData);
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        GameEvents.OnCheckAnswer += OnCheckAnswer;
    }

    private void OnDisable()
    {
        GameEvents.OnCheckAnswer -= OnCheckAnswer;
    }
    public void OnCheckAnswer()
    {
        if(answer == int.Parse(input.text))
        {
            GameEvents.OnPuzzleCompletedMethod();
        }
    }
    
    public void setPuzzleData(List<PuzzleData.PuzzleStoryData> data)
    {
        storyTextElement.text = "";
        int storyID = UnityEngine.Random.Range(0, PuzzleData.ins.puzzleStory_data.Count);
        foreach (PuzzleData.PuzzleStoryData puzzleData in data)
        {
            if (puzzleData.storyID == storyID)
            {
                storyTextElement.text = puzzleData.story;
                this.answer = puzzleData.answer;
                storyBackgroundImage.sprite = Resources.Load<Sprite>("StoryBackgrounds/" + puzzleData.storyBackgroundImage);
                backgroundImage.color = puzzleData.color;
                Debug.Log(puzzleData.color);
            }
        }
    }
}
