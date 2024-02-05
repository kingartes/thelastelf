using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem 
{
    private int width;
    private int height;
    private int cellSize;
    private GridCell[,] cellsArray;

    private delegate void IterateCallback(int x, int z);

    public GridSystem(int width, int height, int cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        cellsArray = new GridCell[width, height];

        IterateCells((int x, int z) =>
        {
            GridPosition gridPosition = new GridPosition(x, z);
            cellsArray[x, z] = new GridCell(gridPosition);
        });
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(Mathf.RoundToInt(worldPosition.x / cellSize), Mathf.RoundToInt(worldPosition.z / cellSize));
    }

    public GridCell GetGridCell(GridPosition gridPosition)
    {
        return ValidatePosition(gridPosition) 
            ? cellsArray[gridPosition.x, gridPosition.z] 
            : null;
    }

    public void CreateDebugObjects(Transform debugPrefab)
    {
        IterateCells((int x, int z) =>
        {
            GridPosition gridPosition = new GridPosition(x, z);
            Transform debugTransform = GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition), Quaternion.identity);
            GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
            gridDebugObject.SetGridObject(GetGridCell(gridPosition));
        });
    }

    public void ClearSelections()
    {
        IterateCells((int x, int z) => cellsArray[x,z].IsSelected = false);
    }

    private void IterateCells(IterateCallback iterateCallback)
    {
        for (int x = 0; x < this.width; x++)
        {
            for (int z = 0; z < this.height; z++)
            {
                iterateCallback(x, z);
            }
        }
    }

    private bool ValidatePosition(GridPosition gridPosition)
    {
        return gridPosition.x >= 0 && gridPosition.x < this.width && gridPosition.z >= 0 && gridPosition.z < this.height;
    }
}
