using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryDeath : MonoBehaviour
{
    public Health PlayerHealth;
    public GameObject Boss;

    public GameObject Player;
    public GameObject DeathScreenUI;
    public GameObject VictoryScreenUI;
    private bool isDead = false;
    private bool bossDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.currentHealth <= 0 && !isDead)
        {
            StartCoroutine(DeathScreen());
        }

        if (Boss == null && !bossDead)
        {
            StartCoroutine(VictoryScreen());
        }

        if (Input.GetKeyDown(KeyCode.Escape) && bossDead)
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R) && isDead)
        {
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator DeathScreen()
    {
        isDead = true;
        DeathScreenUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(Player);
    }

    IEnumerator VictoryScreen()
    {
        bossDead = true;
        VictoryScreenUI.SetActive(true);
        yield return new WaitForSeconds(2f);

    }
}
