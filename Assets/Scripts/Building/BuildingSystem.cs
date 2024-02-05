using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField]
    private Transform buildingPrefab;
    [SerializeField]
    private Material buildingMaterial;

    private bool isBuilding = false;

    private Material originMaterial;

    private Transform buildingBlock;

    private void Update()
    {
        if (InputManager.Instance.IsSwitchBuildingMode())
        {
            isBuilding = !isBuilding;
            if (buildingBlock != null )
            {
                Destroy(buildingBlock.gameObject);
                buildingBlock = null;
            }
        }
        GridPosition gridMousePosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetPosition());
        GridCell gridCell = LevelGrid.Instance.GetGridCell(gridMousePosition);
        LevelGrid.Instance.ClearCelssSelection();
        if (gridCell != null) {
            gridCell.IsSelected = true;
        }

        if (isBuilding)
        {
            InstantiateBuildingBlock();
            buildingBlock.position = LevelGrid.Instance.GetWorldPosition(gridMousePosition);
            if (InputManager.Instance.IsLeftMouseButtonClicked())
            {
                PlaceBuilding(gridMousePosition);
            }
        }
    }

    private void InstantiateBuildingBlock()
    {
        if (buildingBlock != null)
        {
            return;
        }
        buildingBlock = Instantiate(buildingPrefab);
        Collider buildingCollider = buildingBlock.GetComponent<Collider>();
        buildingCollider.enabled = false;
        MeshRenderer buildingRenderer = buildingBlock.GetComponentInChildren<MeshRenderer>();
        originMaterial = buildingRenderer.material;
        buildingRenderer.material = buildingMaterial;
    }

    private void PlaceBuilding(GridPosition gridMousePosition)
    {
        if (buildingBlock == null)
        {
            return;
        }
        Collider buildingCollider = buildingBlock.GetComponent<Collider>();
        buildingCollider.enabled = true;
        MeshRenderer buildingRenderer = buildingBlock.GetComponentInChildren<MeshRenderer>();
        buildingRenderer.material = originMaterial;
        buildingBlock.position = LevelGrid.Instance.GetWorldPosition(gridMousePosition);
        isBuilding = false;
        buildingBlock = null;
    }
}
