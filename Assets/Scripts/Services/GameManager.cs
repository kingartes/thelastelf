using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Starving playerStarving;

    [SerializeField]
    private GameOverUI gameOverUI;

    private void Awake()
    {
        gameOverUI.gameObject.SetActive(false);
    }

    private void PlayerStarving_onStarveExpired(object sender, System.EventArgs e)
    {
        GameOver();
    }

    private void GameOver()
    {
        gameOverUI.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
