using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
    public Matrix()
    {
        
    }
    int Rows, Cols;
    int[,] Array2d;
    int[,] Array2d1 = new int[2, 2] { { 5, 5 }, { 5, 5 } };
    int[,] Array2d2 = new int[2, 2] { { 10, 10 }, { 10, 10 } };

    List<List<int>> MyList = new List<List<int>>();
    public Matrix(int row, int col)
    {
        Array2d = new int[row, col];

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            { Array2d[i, j] = 0; }
        }
    }
    public void MatrixByList(int row, int col)
    {
        for (int i = 0; i < row; i++)
        {
            MyList.Add(new List<int>());
            for (int a = 0; a < col; a++)
            {
                MyList[i].Add(0);
            }
        }
    }
    public void MatrixByArray(int row, int col)
    {
        Array2d = new int[row, col];

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            { Array2d[i, j] = 1; }
        }
    }
    public void MatrixBy2DArray(int[,] Array)
    {
        Array2d = Array;

    }
    public void Print()
    {
        for (int i = 0; i < Array2d.GetLength(0); i++)
        {
            for (int j = 0; j < Array2d.GetLength(1); j++)
            {
                //Array2d[i, j] = 1;
                Debug.Log(Array2d[i, j]);
            }
        }
    }
    public void Print(int[,] Array)
    {
        for (int i = 0; i < Array.GetLength(0); i++)
        {
            for (int j = 0; j < Array.GetLength(1); j++)
            {
                //Array2d[i, j] = 1;
                Debug.Log(Array[i, j]);
            }
        }
    }
    public void SetElement(int row, int col, int Value)
    {
        Array2d[row, col] = Value;
        OnMatrixUpdated();
        //Debug.Log(Array2d[row, col]);
        //MatrixUpdate();
    }
    public int GetElement(int row, int col)
    {
        Debug.Log(Array2d[row, col]);
        return Array2d[row, col];
    }
    public void SetRow(int row, int[] Array)
    {
        for (int i = 0; i < Array.Length; i++)
        {
            Array2d[row, i] = Array[i];
            //Debug.Log("WORKING");
        }
        OnMatrixUpdated();
    }
    public float[] GetRow(int RowNum)
    {
        float[] ans = new float[Array2d.GetLength(0)];
        for (int i = 0; i < Array2d.GetLength(1); i++)
        {
            ans[i] = Array2d[RowNum, i];
        }
        Debug.Log("GetRow Working");
        return ans;
    }
    public void SetColumn(int col, int[] Array)
    {
        for (int i = 0; i < Array.Length; i++)
        {
            Array2d[i, col] = Array[i];
            //Debug.Log("WORKING");
        }
        OnMatrixUpdated();
    }
    public void SwapRows(int R1, int R2)
    {

        for (int i = 0; i < Array2d.GetLength(1); i++)
        {
            int temp = Array2d[R2, i];
            Array2d[R2, i] = Array2d[R1, i];
            Array2d[R1, i] = temp;

            //var temp = Array2d[i, j];
            //temp = R2;
            //R2 = R1;
            //R1 = temp;
        }
        Debug.Log("SWAPT METHOD WORKED");
    }
    public void SwapCols(int C1, int C2)
    {
        for (int i = 0; i < Array2d.GetLength(1); i++)
        {
            int temp = Array2d[i, C2];
            Array2d[i, C2] = Array2d[i, C1];
            Array2d[i, C1] = temp;
        }
        Debug.Log("SWAPT METHOD WORKED");
    }
    public int[,] AddMatrix(int[,] Array)
    {
        int[,] temp = new int[2, 2];
        for (int i = 0; i < Array.GetLength(0); i++)
        {
            for (int j = 0; j < Array.GetLength(1); j++)
            {
                Array2d[i, j] = Array[i, j] + Array2d[i, j];

            }
        }
        Debug.Log("ADD MATRIX METHOD WORKED");
        return Array2d;
    }
    public int[,] SubtMatrix(int[,] Array)
    {
        int[,] temp = new int[2, 2];
        for (int i = 0; i < Array.GetLength(0); i++)
        {
            for (int j = 0; j < Array.GetLength(1); j++)
            {
                Array2d[i, j] = Array[i, j] - Array2d[i, j];
            }
        }
        Debug.Log("Subtract Method worked");
        return Array2d;
    }
    public void SetMatrix(int num)
    {

        for (int i = 0; i < Array2d.GetLength(0); i++)
        {
            for (int j = 0; j < Array2d.GetLength(1); j++)
            { Array2d[i, j] = num; }
        }
        OnMatrixUpdated();
    }
    public void SetRow(int row, int num)
    {
        for (int i = 0; i < Array2d.GetLength(0); i++)
        {
            Array2d[row, i] = num;

        }
        Debug.Log("WORKING");
        OnMatrixUpdated();
    }
    public void SetCol(int Col, int num)
    {
        for (int i = 0; i < Array2d.GetLength(0); i++)
        {
            Array2d[i, Col] = num;

        }
        Debug.Log("WORKING");
        OnMatrixUpdated();
    }
    public void SetDaigonal(int num)
    {
        for (int i = 0; i < Array2d.GetLength(0); i++)
        {
            Array2d[i, i] = num;
        }
        Debug.Log("SetDaigonal working");
        OnMatrixUpdated();
    }
    public void SetInverseDaigonal(int num)
    {
        for (int i = 0; i < Array2d.GetLength(0); i++)
        {
            Array2d[i, Array2d.GetLength(0) - 1 - i] = num;
        }
        OnMatrixUpdated();
    }
    public bool IsRowSame(int RowNum)
    {
        bool Ans = true;
        for (int i = 0; i < Array2d.GetLength(0) - 1; i++)
        {
            if (Array2d[RowNum, i] != Array2d[RowNum, i + 1])
            {
                Ans = false;
            }
        }
        //Debug.Log("IsRowSame Working");
        return Ans;
    }
    public bool IsColSame(int ColNum)
    {
        bool Ans = true;
        for (int i = 0; i < Array2d.GetLength(1) - 1; i++)
        {
            if (Array2d[i, ColNum] != Array2d[i + 1, ColNum])
            {
                Ans = false;
            }
            
        }
        //Debug.Log("IsColSame Working");
        return Ans;
    }
    public bool IsDaigonalSame()
    {
        bool ans = true;
        for (int i = 0; i < Array2d.GetLength(0) - 1; i++)
        {
            if (Array2d[i, i] != Array2d[i + 1, i + 1])
            {
                ans = false;
            }

        }
        //Debug.Log("IS Daigonal working");

        return ans;
    }
    public bool IsInverseDaigonalSame()
    {
        bool ans = true;
        for (int i = 0; i < Array2d.GetLength(0) - 1; i++)
        {
            if (Array2d[i, Array2d.GetLength(0) - 1 - i] != Array2d[i + 1, Array2d.GetLength(0) - 2 - i])
            {
                ans = false;
            }
        }
        Debug.Log("Inverse Daigonal working");

        return ans;
    }
    public int[,] Multiply(int[,] Array)
    {
        int[,] Arraytemp = new int[Array2d.GetLength(0), Array2d.GetLength(1)];
        for (int row = 0; row < Array2d.GetLength(0); row++)
        {
            for (int Col = 0; Col < Array2d.GetLength(1); Col++)
            {
                for (int i = 0; i < Array2d.GetLength(0); i++)
                {
                    Arraytemp[row, Col] = Arraytemp[row, Col] + Array2d[row, i] * Array[i, Col];
                }
            }
        }
        Print(Arraytemp);
        return Arraytemp;
    }
    public int Determinant(int[,] Array)
    {
        int ans = 0;
        ans = (Array[0, 0] * Array[1, 1]) - (Array[0, 1] * Array[1, 0]);
        return ans;
    }

    public int[,] ReturnArray()
    {
        return Array2d;
    }
    public virtual void OnMatrixUpdated()
    {
        
    }


}
