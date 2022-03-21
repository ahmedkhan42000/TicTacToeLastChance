using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGrid : Matrix
{
    int NumofRow, NumofCol;

    Cell[,] CellGrid;
    Cell.Status CurrentTurn = Cell.Status.Cross;

    public delegate void OnCellCreated(Cell cell);
    public OnCellCreated onCellCreated;

    public delegate void OnAllCellDone();
    public OnAllCellDone onAllCellDone;

    public TicTacToeGrid(int row, int col) : base( row, col)
    {
        //Debug.Log("tictactoe grid constructor working");
    }
    public void InitializeCell(int row, int col)
    {
        //Debug.Log("InitializeCell  working");
        CellGrid = new Cell[row,col];
        NumofRow = CellGrid.GetLength(0);
        NumofCol = CellGrid.GetLength(1);
        for (int i = 0; i < CellGrid.GetLength(0); i++)
        {
            for (int j = 0; j < CellGrid.GetLength(1); j++)
            {
                CellGrid[i, j] = new Cell(i,j);
                onCellCreated?.Invoke(CellGrid[i,j]);
                CellGrid[i, j].rowAndCol_D += SetStatusturn; 
            }
        }
        onAllCellDone?.Invoke();
    }
    public void SetStatusturn(int row, int col)
    {
        if (CellGrid[row,col].GetStatus() == Cell.Status.None )
        {
            TakeTurn(row, col);
            //CellGrid[row, col].SetStatus(CurrentTurn);
            SetElement(row,col,(int)CurrentTurn);
            CheckWin(row,col);
        }
       
    }

    private void TakeTurn(int row, int col)
    {
        if (CurrentTurn == Cell.Status.Cross)
        {
            CurrentTurn = Cell.Status.Circle;
        }
        else
        {
            CurrentTurn = Cell.Status.Cross;
        }
    }
    private void CheckWin(int row, int col)
    {
        CheckRow(row);
        CheckCol(col);
        CheckDaigonal(row,col);
        CheckInverseDaigonal(row,col);
    }
    private void CheckRow(int row)
    {
        if (IsRowSame(row))
        {
            SetRow(row,(int)Cell.Status.Win);
        }
    }
    private void CheckCol(int col)
    {
        if (IsColSame(col))
        {
            SetCol(col, (int)Cell.Status.Win);
        }
    }
    private void CheckDaigonal(int row, int col)
    {
        if (row == col)
        {
            if (IsDaigonalSame())
            {
                SetDaigonal((int)Cell.Status.Win);
            }
        }
        
    }
    private void CheckInverseDaigonal(int row, int col)
    {
        if (row == CellGrid.GetLength(0)-1-col)
        {
            if (IsInverseDaigonalSame())
            {
                SetInverseDaigonal((int)Cell.Status.Win);
                Debug.Log("IsInverseDaigonalSame WORKING");
            }
            Debug.Log("InverseDaigonal Cell WORKING");
        }
    }

   

  


    public override void OnMatrixUpdated()
    {
        for (int i = 0; i < NumofRow; i++)
        {
            for (int j = 0; j < NumofCol; j++)
            {
                CellGrid[i, j].SetStatus((Cell.Status)GetElement(i, j));
            }

        }

    }
}
