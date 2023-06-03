using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NoteButton : Selectable, IPointerClickHandler
{
    public Sprite on_image;
    public Sprite off_image;

    private bool active_;

    void Start()
    {
        active_ = false;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        active_ = !active_;

        if (active_)
        {
            GetComponent<Image>().sprite = on_image;
        } else
        {
            GetComponent<Image>().sprite = off_image;
        }
        GameEvents.OnNotesActiveMethod(active_);
    }

}
