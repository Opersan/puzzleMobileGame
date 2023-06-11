using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWon : MonoBehaviour
{
    public GameObject WinPopup;
    void Start()
    {
        WinPopup.SetActive(false);
    }

    private void OnPuzzleCompleted()
    {
        WinPopup.SetActive(true);
        GameEvents.OnGameOverMethod();
    }

    private void OnEnable()
    {
        GameEvents.OnPuzzleCompleted += OnPuzzleCompleted;
    }
    private void OnDisable()
    {
        GameEvents.OnPuzzleCompleted -= OnPuzzleCompleted;
    }

}
