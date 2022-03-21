using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeView : MonoBehaviour
{
    public int InputRow, InputCol;
    int TempCounter = 0;
    float HorizontalSpacing = 0, VerticalSpacing = 0;

    public GameObject CellPf;

    TicTacToeGrid TTTGrid;    // Start is called before the first frame update
    void Start()
    {
        InitialiazeGird();
    }

    private void InitialiazeGird()
    {
        //Debug.Log("InitilizeGrid Woking Of TTTV class");
        TTTGrid = new TicTacToeGrid(InputRow,InputCol);
        TTTGrid.onCellCreated += OnCellCreated;
        TTTGrid.onAllCellDone += OnAllCellDone;
        TTTGrid.InitializeCell(InputRow,InputCol);
    }

    private void OnCellCreated(Cell cell)
    {
        //Debug.Log("oncell created working");
        AllignCell();
        GameObject cellViewTemp = Instantiate(CellPf, new Vector3(HorizontalSpacing, 0 ,VerticalSpacing), CellPf.transform.rotation);
        cellViewTemp.GetComponent<CellView>().SetCell(cell);
        cellViewTemp.GetComponent<CellView>().SetStatus(Cell.Status.None);
        TempCounter++;
    }

    private void AllignCell()
    {
        if (TempCounter == InputRow)
        {
            HorizontalSpacing = 2;
            TempCounter = 0;
            VerticalSpacing += 2;
        }
        else
        {
            HorizontalSpacing += 2;
        }
    }

    private void CellPosition()
    {
        
    }

    private void OnAllCellDone()
    {
    }

    
}
