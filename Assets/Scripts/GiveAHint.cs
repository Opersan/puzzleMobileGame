using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GiveAHint : MonoBehaviour
{
    private Button button;
    private int count;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
        button.interactable = true;
        count = 3;
    }

    private void OnButtonClicked()
    {
        GameEvents.OnHintRewardMethod();
    }

    private void OnEnable()
    {
        GameEvents.OnHintReward += OnGiveHint;  
    }

    private void OnDisable()
    {
        GameEvents.OnHintReward -= OnGiveHint;
    }
    private void OnGiveHint()
    {
        count--;
        if(count == 0)
        {
            button.interactable = false;    
        }
    }
}
