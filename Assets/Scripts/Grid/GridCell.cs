using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell 
{
    private GridPosition gridPosition;
    public bool IsSelected { get; set; }

    public GridCell(GridPosition gridPosition)
    {
        this.gridPosition = gridPosition;
    }

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }

    public override string ToString()
    {
        return $"{gridPosition.ToString()}";
    }
}
