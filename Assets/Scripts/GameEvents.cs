using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void CheckBoardCompleted();
    public static event CheckBoardCompleted OnCheckBoardCompleted;
    public static void CheckBoardCompletedMethod()
    {
        if (OnCheckBoardCompleted != null)
        {
            OnCheckBoardCompleted();
        }
    }

    public delegate void UpdateSquareNumber(int number);
    public static event UpdateSquareNumber OnUpdateSquareNumber;
    public static void UpdateSquareNumberMethod(int number)
    {
        if(OnUpdateSquareNumber != null)
        {
            OnUpdateSquareNumber(number);
        }
    }

    public delegate void SquareSelected(int square_index);
    public static event SquareSelected OnSquareSelected;
    public static void SquareSelectedMethod(int square_index)
    {
        if (OnSquareSelected != null)
        {
            OnSquareSelected(square_index);
        }
    }

    public delegate void WrongNumber();
    public static event WrongNumber OnWrongNumber;
    public static void OnWrongNumberMethod()
    {
        if (OnWrongNumber != null)
        {
            OnWrongNumber();
        }
    }

    public delegate void GameOver();
    public static event GameOver OnGameOver;
    public static void OnGameOverMethod()
    {
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }

    public delegate void NotesActive(bool active);
    public static event NotesActive OnNotesActive;
    public static void OnNotesActiveMethod(bool active)
    {
        if (OnNotesActive != null)
        {
            OnNotesActive(active);
        }
    }

    public delegate void ClearNumber();
    public static event ClearNumber OnClearNumber;
    public static void OnClearNumberMethod()
    {
        if (OnClearNumber != null)
        {
            OnClearNumber();
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

    public delegate void HintReward();
    public static event HintReward OnHintReward;
    public static void OnHintRewardMethod()
    {
        if (OnHintReward != null)
        {
            OnHintReward();
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
