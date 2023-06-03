using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEvents;

public class Grid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public float square_offset = 0.0f;
    public GameObject grid_square;
    public Vector2 start_position = new Vector2(0.0f, 0.0f);
    public float square_scale = 1.0f;
    public float square_gap = 0.1f;
    public Color line_highlight_color = Color.red;

    private List<GameObject> grid_square_ = new List<GameObject>();
    private int selected_grid_data = -1;


    // Start is called before the first frame update
    void Start()
    {
        if (grid_square.GetComponent<GridSquare>() == null)
        {
            Debug.LogError("This Game Object need to have GridSquare script attached");
        }
        CreateGrid();

        if(GameSettings.ins.GetContinuePreviousGame())
        {
            SetGridFormFile();
        } else
        {
            SetGridNumber(GameSettings.ins.GetGameMode());
        }
    }

    void SetGridFormFile()
    {
        string level = GameSettings.ins.GetGameMode();
        selected_grid_data = Config.ReadGameBoardLevel();
        var data = Config.ReadGridData();
        setGridSquareData(data);
        SetGridNotes(Config.GetGridNotes());
    }

    private void SetGridNotes(Dictionary<int, List<int>> notes)
    {
        foreach(var note in notes)
        {
            grid_square_[note.Key].GetComponent<GridSquare>().SetGridNotes(note.Value);
        }
    }

    private void CreateGrid()
    {
        SpawnGridSquares();
        SetSquaresPosition();
    }

    private void SpawnGridSquares()
    {
        int square_index = 0;
        for( int row = 0; row < rows; row++ )
        {
            for (int column = 0; column < columns; column++)
            {
                grid_square_.Add(Instantiate(grid_square) as GameObject);
                grid_square_[grid_square_.Count - 1].GetComponent<GridSquare>().SetSquareIndex(square_index);
                grid_square_[grid_square_.Count - 1].transform.SetParent(this.transform);
                grid_square_[grid_square_.Count - 1].transform.localScale = new Vector3(square_scale, square_scale, square_scale);
                square_index++;
            }
        }
        
    }

    private void SetSquaresPosition()
    {
        var square_rect = grid_square_[0].GetComponent<RectTransform>();
        Vector2 offset = new Vector2();
        Vector2 square_gap_number = new Vector2(0.0f, 0.0f);
        bool row_moved = false;

        offset.x = square_rect.rect.width * square_rect.transform.localScale.x + square_offset;
        offset.y = square_rect.rect.height * square_rect.transform.localScale.y + square_offset;

        int column_number = 0;
        int row_number = 0;

        foreach (GameObject square in grid_square_)
        {
            if (column_number + 1 > columns)
            {
                row_number++;
                column_number = 0;
                square_gap_number.x = 0;
                row_moved = false;
            }

            var pos_x_offset = offset.x * column_number + (square_gap_number.x * square_gap);
            var pos_y_offset = offset.y * row_number + (square_gap_number.y * square_gap);

            if(column_number > 0 && column_number % 3 == 0)
            {
                square_gap_number.x++;
                pos_x_offset += square_gap;
            }
            if (row_number > 0 && row_number % 3 == 0 && row_moved == false)
            {
                row_moved = true;
                square_gap_number.y++;
                pos_y_offset += square_gap;
            }

            square.GetComponent<RectTransform>().anchoredPosition = new Vector2(start_position.x + pos_x_offset,
                start_position.y - pos_y_offset);
            column_number++;

        }
    }

    private void SetGridNumber(string level)
    {
        selected_grid_data = UnityEngine.Random.Range(0, SudokuData.ins.sudoku_game[level].Count);
        var data = SudokuData.ins.sudoku_game[level][selected_grid_data];

        setGridSquareData(data);
    }
    private void setGridSquareData(SudokuData.SudokuBoardData data)
    {
        for (int i = 0; i < grid_square_.Count; i++)
        {
            grid_square_[i].GetComponent<GridSquare>().SetHasDefaultValue(data.unsolved_data[i] != 0 && data.unsolved_data[i] == data.solved_data[i]);
            grid_square_[i].GetComponent<GridSquare>().SetNumber(data.unsolved_data[i]);
            grid_square_[i].GetComponent<GridSquare>().SetCorrectNumber(data.solved_data[i]);
        }
    }

    private void OnEnable()
    {
        GameEvents.OnSquareSelected += OnSquareSelected;
        GameEvents.OnCheckBoardCompleted += CheckBoardCompleted;
        GameEvents.OnHintReward += OnHintReward;
    }

    private void OnDisable()
    {
        GameEvents.OnSquareSelected -= OnSquareSelected;
        GameEvents.OnCheckBoardCompleted -= CheckBoardCompleted;
        GameEvents.OnHintReward -= OnHintReward;

        var solved_data = SudokuData.ins.sudoku_game[GameSettings.ins.GetGameMode()][selected_grid_data].solved_data;
        int[] unsolved_data = new int[81]; 
        Dictionary<string, List<string>> grid_notes = new Dictionary<string, List<string>>();   

        for(int i = 0; i < grid_square_.Count; i++)
        {
            var comp = grid_square_[i].GetComponent<GridSquare>();
            unsolved_data[i] = comp.GetSquareNumber();
            string key = "square_note:" + i.ToString();
            grid_notes.Add(key, comp.GetSquareNotes()); 
        }

        SudokuData.SudokuBoardData current_game_data = new SudokuData.SudokuBoardData(unsolved_data, solved_data);
        if(!GameSettings.ins.GetExitAfterWon())
        {
            Config.SaveBoardData(current_game_data,
                GameSettings.ins.GetGameMode(),
                selected_grid_data,
                Lives.ins.GetErrorNumber(),
                grid_notes);
        } else
        {
            Config.DeleteDataFile();
        }
        GameSettings.ins.SetExitAfterWon(false);
    }

    private void SetSquaresColor(int[] data, Color col)
    {
        foreach(var i in data)
        {
            var comp = grid_square_[i].GetComponent<GridSquare>();
            if(comp.HasWrongValue() == false && comp.IsSelected() == false)
            {
                comp.SetSquareColor(col);
            }
        }
    }

    public void OnSquareSelected(int square_index)
    {
        var horizontal_line = LineIndicator.ins.getHorizontalLine(square_index);
        var vertical_line = LineIndicator.ins.getVericalLine(square_index);
        var square = LineIndicator.ins.GetSquare(square_index);

        if (grid_square_[square_index].GetComponent<GridSquare>().GetHasDefaultValue() == false)
        {
            SetSquaresColor(LineIndicator.ins.GetAllSquaresIndexes(), Color.white);
            SetSquaresColor(horizontal_line, line_highlight_color);
            SetSquaresColor(vertical_line, line_highlight_color);
            SetSquaresColor(square, line_highlight_color);
        } else
        {
            foreach(var gridSquare in grid_square_)
            {
                var comp = gridSquare.GetComponent<GridSquare>();
                if(comp.HasWrongValue() == false && comp.IsSelected() == false)
                {
                    comp.SetSquareColor(Color.white);
                }
            }
        }

       
    }
    
    private void CheckBoardCompleted()
    {
        foreach(var square in grid_square_)
        {
            var comp = square.GetComponent<GridSquare>();
            if (comp.IsCorrectNumberSet() == false)
            {
                return;
            }
        }
        GameEvents.OnBoardCompletedMethod();
    }

    public void SolveSudoku()
    {
        foreach(var square in grid_square_)
        {
            var comp = square.GetComponent<GridSquare>();
            comp.SetCorrectNumber();
        }

        CheckBoardCompleted();
    }

    public void OnHintReward()
    {
        var squareIndexes = new List<int>();

        for (var i = 0; i < grid_square_.Count; i++)
        {
            var comp = grid_square_[i].GetComponent<GridSquare>();
            if(comp.GetSquareNumber() == 0 && comp.GetHasDefaultValue() == false)
            {
                squareIndexes.Add(i);
            }
        }

        if(squareIndexes.Count == 0 ) 
        {
            return;
        }
        var random_index = UnityEngine.Random.Range(0, squareIndexes.Count);
        var square_index = squareIndexes[random_index];
        grid_square_[square_index].GetComponent<GridSquare>().SetCorrectValueOnHint();
    }
}
