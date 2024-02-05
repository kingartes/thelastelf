using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarvingUI : MonoBehaviour
{
    [SerializeField]
    private Starving playerStarving;

    [SerializeField]
    private Image starvingBar;

    private void Start()
    {
        playerStarving.onStarveChanged += PlayerStarving_onStarveChanged;
    }

    private void PlayerStarving_onStarveChanged(object sender, System.EventArgs e)
    {
        UpdateStarvingBar();
    }

    private void UpdateStarvingBar()
    {
        starvingBar.fillAmount = playerStarving.GetStarvingNormalized();
    }
}
