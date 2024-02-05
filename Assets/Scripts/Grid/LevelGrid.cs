using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : SingletoneComponent<LevelGrid>
{
    [SerializeField]
    private Transform debugCell;
    [SerializeField]
    private int width = 10;
    [SerializeField]
    private int height = 10;
    [SerializeField]
    private int cellSize = 2;

    private GridSystem gridSystem;
    
    void Start()
    {
        gridSystem = new GridSystem(width, height, cellSize);
        gridSystem.CreateDebugObjects(debugCell);
    }


    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);
    
    public GridCell GetGridCell(GridPosition gridPosition) => gridSystem.GetGridCell(gridPosition);

    public void ClearCelssSelection() => gridSystem.ClearSelections();
 }
