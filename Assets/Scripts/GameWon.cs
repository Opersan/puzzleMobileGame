using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWon : MonoBehaviour
{
    public GameObject WinPopup;
    public Text ClockText;
    void Start()
    {
        WinPopup.SetActive(false);
    }

    private void OnBoardCompleted()
    {
        WinPopup.SetActive(true);
        GameEvents.OnGameOverMethod();
        ClockText.text = Clock.ins.GetCurrentTimeText().text;
    }

    private void OnEnable()
    {
        GameEvents.OnBoardCompleted += OnBoardCompleted;
    }
    private void OnDisable()
    {
        GameEvents.OnBoardCompleted -= OnBoardCompleted;
    }

}
