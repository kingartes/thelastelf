using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro gridText;
    [SerializeField]
    private MeshRenderer cellRenderer;
    [SerializeField]
    private Material SelectedMaterial;
    [SerializeField]
    private Material UnselectedMaterial;

    private GridCell gridObject;

    public virtual void SetGridObject(GridCell gridObject)
    {
        this.gridObject = gridObject;
    }

    protected virtual void Update()
    {
        gridText.text = gridObject.ToString();
        cellRenderer.material  = gridObject.IsSelected ?  SelectedMaterial : UnselectedMaterial;
    }

}
