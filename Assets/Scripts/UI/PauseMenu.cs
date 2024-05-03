using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseCanvas;

    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseCanvas.gameObject.SetActive(true);
            isPaused = true;
        }
        else if (isPaused)
        {
            pauseCanvas.gameObject.SetActive(false);
            isPaused = false;
        }
    }

    public void ResumeGame()
    {
        pauseCanvas.gameObject.SetActive(false);
        isPaused = false;
    }


    public void QuitGame()
    {

    }    
}
