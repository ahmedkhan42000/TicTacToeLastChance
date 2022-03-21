using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    int Row, Col;
    public enum Status {None, Cross, Circle, Win, Loose};
    Status status;

    public delegate void StatusUpdated(Status status);
    public StatusUpdated statusUpdated_D;

    public delegate void RowAndCol(int row, int col);
    public RowAndCol rowAndCol_D;

    public Cell(int row, int col)
    {
        this.Row = row;
        this.Col = col;
        status = Status.None;
    }
    public Cell()
    {
        Row = 0;
        Col = 0;
        status = Status.None;
    }
    public void SetStatus(Status status1)
    {
        status = status1;
        statusUpdated_D?.Invoke(status1);
    }
    public Status GetStatus()
    {
        return status; 
    }
    public void SetRow(int row)
    {
        this.Row = row;
    }
    public void SetCol(int col)
    {
        this.Col = col;
    }
    public int GetRow()
    {
        return Row;
    }
    public int GetCol()
    {
        return Col;
    }

    public void Interaction()
    {
        rowAndCol_D?.Invoke(Row, Col);
        //SetStatus(Status.Win);
    }
}
