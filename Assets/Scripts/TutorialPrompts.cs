using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPrompts : MonoBehaviour
{
    public int tutorialPromptNumber;
    public GameObject tutorialPrompt;
    private bool moveComplete = false;
    private bool hasShot = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveComplete && tutorialPromptNumber == 0)
        {
            CheckMoveInput();
        }
        else if (moveComplete)
        {
            tutorialPrompt.SetActive(false);
        }

        if (!hasShot && tutorialPromptNumber == 1) 
        {
            CheckAttackInput();
        }
        else if (hasShot)
        {
            tutorialPrompt.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tutorialPrompt.SetActive(true);
        }
    }

    public void CheckMoveInput()
    {
        bool wPressed = false;
        bool aPressed = false;
        bool dPressed = false;
        bool sPressed = false;  
        
        if (Input.GetKeyDown(KeyCode.W))
            wPressed = true;

        if (Input.GetKeyDown(KeyCode.A))
            aPressed = true;

        if (Input.GetKeyDown(KeyCode.S))
            sPressed = true;

        if (Input.GetKeyDown(KeyCode.D))
            dPressed = true;


        if (wPressed && dPressed && sPressed && aPressed)
            moveComplete = true;
    }

    public void CheckAttackInput()
    {
        if (InputManager.Instance.IsPrimaryActionReleased() && !hasShot)
        {
            hasShot = true;
        }
    }

    public void CheckCraftInput()
    {

    }
}
