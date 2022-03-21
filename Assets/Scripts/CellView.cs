using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{
    Cell cell = new Cell();
    public GameObject[] CubeStatus;

        public void SetStatus( Cell.Status status)
    { 
        //Debug.Log("set status working");
        for (int i = 0; i < CubeStatus.Length; i++)
        {
            if (i == (int)status  )
            {
                CubeStatus[i].SetActive(true);
            }
            else
            {
                CubeStatus[i].SetActive(false);
            }
        }
    }
    private void Start()
    {
        cell.statusUpdated_D += SetStatus; // function ki taraf point kara raha ha (upar walay setstatus ki taraf)
    }
    private void OnMouseDown()
    {
        cell.Interaction();
    }
    public void SetCell(Cell cell)
    {
        this.cell = cell;
    }

}
