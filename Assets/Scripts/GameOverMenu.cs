using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Text textClock;
    void Start()
    {
        textClock.text = Clock.ins.GetCurrentTimeText().text;
    }

}
