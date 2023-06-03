using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static GameEvents;
using Unity.VisualScripting;

public class GridSquare : Selectable, IPointerClickHandler, ISubmitHandler, IPointerUpHandler, IPointerExitHandler
{
    public GameObject number_text;
    public List<GameObject> number_notes;
    private bool note_active;

    private int number_ = 0;
    private int correct_number_ = 0;
    
    // Checks selected grid
    private bool selected_ = false;
    private int square_index = -1;
    // Checks if it grid has default value
    private bool has_default_value_ = false;
    private bool has_wrong_value = false;

    public int GetSquareNumber()
    {
        return number_;
    }
    public bool IsCorrectNumberSet()
    {
        return number_ == correct_number_;
    }

    public bool HasWrongValue()
    {
        return has_wrong_value;
    }
    public void SetHasDefaultValue(bool has_default)
    {
        has_default_value_ = has_default;
    }

    public bool GetHasDefaultValue()
    {
        return has_default_value_;
    }


    public bool IsSelected()
    {
        return selected_;
    }

    public void SetSquareIndex(int square_index)
    {
        this.square_index = square_index;
    }

    public void SetCorrectNumber(int number)
    {
        correct_number_ = number;
        has_wrong_value = false;

        if(number_ != 0 && number_ != correct_number_)
        {
            has_wrong_value = true;
            SetSquareColor(Color.red);
        }
    }

    public void SetCorrectNumber()
    {
        number_ = correct_number_;
        SetNoteNumberValue(0);
        DisplayText();
    }

    void Start()
    {
        selected_ = false;
        note_active = false;

        if(GameSettings.ins.GetContinuePreviousGame() == false)
        {
            SetNoteNumberValue(0);
        }
        else
        {
            SetClearEmptyNotes();

        }

    }
   
    public List<string> GetSquareNotes()
    {
        List<string> notes = new List<string>();

        foreach (var number in number_notes)
        {
            notes.Add(number.GetComponent<Text>().text);
        }

        return notes;
    }

    private void SetClearEmptyNotes()
    {
        foreach(var number in number_notes)
        {
            if(number.GetComponent<Text>().text == "0")
            {
                number.GetComponent<Text>().text = " ";
            }
        }
    }

    private void SetNoteNumberValue(int value)
    {
        foreach (var number in number_notes)
        {
            if (value <= 0)
            {
                number.GetComponent<Text>().text = " ";
            }
            else
            {
                number.GetComponent<Text>().text = value.ToString();
            }
        }
    }

    public void SetNoteSingleNumberValue(int value, bool force_update = false)
    {
        if(!note_active && !force_update)
        {
            return;
        }
        if(value <= 0)
        {
            number_notes[value - 1].GetComponent<Text>().text = " ";
        } else
        {
            if (number_notes[value - 1].GetComponent<Text>().text == " " || force_update)
            {
                number_notes[value - 1].GetComponent<Text>().text = value.ToString();
            }
            else
            {
                number_notes[value - 1].GetComponent<Text>().text = " ";
            }
        }
    }

    public void SetGridNotes(List<int> notes)
    {
        foreach(var note in notes)
        {
            SetNoteSingleNumberValue(note, true);
        }
    }

    public void OnNoteActive(bool active)
    {
        note_active = active;
    }
    
    public void DisplayText()
    {
        if (number_ <= 0)
        {
            number_text.GetComponent<Text>().text = " "; 
        }
        else
        {
            number_text.GetComponent<Text>().text = number_.ToString();
        }
        if(has_default_value_)
        {
            number_text.GetComponent<Text>().fontStyle = FontStyle.Bold;
        }
    }
    
    public void SetNumber(int number)
    {
        number_ = number;
        DisplayText();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selected_ = true;
        GameEvents.SquareSelectedMethod(square_index);
    }
    public void OnSubmit(BaseEventData eventData)
    {

    }

    private void OnEnable()
    {
        GameEvents.OnUpdateSquareNumber += OnSetNumber;
        GameEvents.OnSquareSelected += OnSquareSelected;
        GameEvents.OnNotesActive += OnNoteActive;
        GameEvents.OnClearNumber += OnClearNumber;
    }
    private void OnDisable()
    {
        GameEvents.OnUpdateSquareNumber -= OnSetNumber;
        GameEvents.OnSquareSelected  -= OnSquareSelected;
        GameEvents.OnNotesActive -= OnNoteActive;
        GameEvents.OnClearNumber -= OnClearNumber;
    }

    public void OnClearNumber()
    {
        if(selected_ && !has_default_value_)
        {
            number_ = 0;
            has_wrong_value = false;
            SetSquareColor(Color.white);
            SetNoteNumberValue(0);
            DisplayText();
        }
    }

    public void SetCorrectValueOnHint()
    {
        SetSquareNumber(correct_number_);
    }

    public void OnSetNumber(int number)
    {
        if(selected_ && has_default_value_ == false)
        {
            SetSquareNumber(number);
        }
    }

    private void SetSquareNumber(int number)
    {
        if (note_active && !has_wrong_value)
        {
            SetNoteSingleNumberValue(number);
        }
        else if (!note_active)
        {
            SetNoteNumberValue(0);
            SetNumber(number);
            if (number_ != correct_number_)
            {
                has_wrong_value = true;
                var colors = this.colors;
                colors.normalColor = Color.red;
                this.colors = colors;

                GameEvents.OnWrongNumberMethod();
            }
            else
            {
                has_wrong_value = false;
                has_default_value_ = true;
                var colors = this.colors;
                colors.normalColor = Color.white;
                this.colors = colors;
            }
        }
        GameEvents.CheckBoardCompletedMethod();
    }

    public void OnSquareSelected(int square_index)
    {
        if (this.square_index != square_index) 
        {
            selected_ = false;
        }
    }

    public void SetSquareColor(Color col)
    {
        var colors = this.colors;
        colors.normalColor = col;
        this.colors = colors;
    }

   
}
