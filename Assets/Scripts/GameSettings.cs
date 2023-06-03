using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
   public enum EGameMode
    {
        NOT_SET,
        EASY,
        MEDIUM,
        HARD,
        VERY_HARD
    }

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

    private EGameMode _GameMode;
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
        _GameMode = EGameMode.NOT_SET;
        continuePreviousGame = false;
    }

    public void SetGameMode(EGameMode mode)
    {
        _GameMode = mode;
    }

    public void SetGameMode(string mode)
    {
        if(mode == "Easy") SetGameMode(EGameMode.EASY);
        else if(mode == "Medium") SetGameMode(EGameMode.MEDIUM);
        else if (mode == "Hard") SetGameMode(EGameMode.HARD);
        else if (mode == "VeryHard") SetGameMode(EGameMode.VERY_HARD);
        else SetGameMode(EGameMode.NOT_SET);
    }

    public string GetGameMode()
    {
        switch(_GameMode)
        {
            case EGameMode.EASY: return "Easy";
            case EGameMode.MEDIUM: return "Medium";
            case EGameMode.HARD: return "Hard";
            case EGameMode.VERY_HARD: return "VeryHard";
        }
        Debug.LogError("ERROR: Game Level is not set");
        return "";
    }

}
