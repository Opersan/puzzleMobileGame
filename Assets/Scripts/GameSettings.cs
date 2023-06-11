using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{

    public static GameSettings ins;

    private void Awake()
    {
        paused = false;
        if (ins == null)
        {
            DontDestroyOnLoad(this);
            ins = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private bool continuePreviousGame = false;
    private bool exitAfterWon = false;
    private bool paused = false;

    public void SetExitAfterWon(bool set)
    {
        exitAfterWon = set;
        continuePreviousGame = false;
    }

    public bool GetExitAfterWon()
    {
        return exitAfterWon;
    }

    public void SetContinuePreviousGame(bool continue_game)
    {
        continuePreviousGame = continue_game;
    }

    public bool GetContinuePreviousGame()
    {
        return continuePreviousGame;
    }
    public void SetPaused(bool paused)
    {
        this.paused = paused;
    }
    public bool getPaused()
    {
        return paused;
    }

    private void Start()
    {
        continuePreviousGame = false;
    }

}
