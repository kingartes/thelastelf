using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject StartGameScreen;
    public GameObject OptionsScreen;
    public GameObject QuitScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        StartGameScreen.SetActive(true);
    }

    public void Options()
    {
        OptionsScreen.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGameConfirmation()
    {
        QuitScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
