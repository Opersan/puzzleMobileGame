using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContinueButton : MonoBehaviour
{

    void Start()
    {
            gameObject.GetComponent<Button>().interactable = false;

    }
}
