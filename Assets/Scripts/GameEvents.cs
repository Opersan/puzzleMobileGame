using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void GameOver();
    public static event GameOver OnGameOver;
    public static void OnGameOverMethod()
    {
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }

    public delegate void PuzzleCompleted();
    public static event PuzzleCompleted OnPuzzleCompleted;
    public static void OnPuzzleCompletedMethod()
    {
        if (OnPuzzleCompleted != null)
        {
            OnPuzzleCompleted();
        }
    }

    public delegate void CheckAnswer();
    public static event CheckAnswer OnCheckAnswer;
    public static void OnCheckAnswerMethod()
    {
       if(OnCheckAnswer != null)
        {
            OnCheckAnswer();
        }
    }
}
