using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPrompts : MonoBehaviour
{
    public int tutorialPromptNumber;
    public GameObject tutorialPrompt;
    private bool moveComplete = false;
    private bool hasShot = false;
    private bool hasDodged = false;
    private bool hasCrafted = false;
    private bool tutorialEnabled = false;

    private bool wPressed = false;
    private bool aPressed = false;
    private bool dPressed = false;
    private bool sPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        if (tutorialPromptNumber == 0)
        {
            tutorialEnabled = true;
            tutorialPrompt.SetActive(true);
        }

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
            Destroy(tutorialPrompt);
        }

        if (!hasShot && tutorialPromptNumber == 1) 
        {
            CheckAttackInput();
        }
        else if (hasShot)
        {
            Destroy(tutorialPrompt);
        }

        if (!hasDodged && tutorialPromptNumber == 2)
        {
            CheckDodgeInput();
        }
        else if (hasDodged)
        {
            Destroy(tutorialPrompt);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tutorialEnabled = true;
            tutorialPrompt.SetActive(true);
        }
    }

    public void CheckMoveInput()
    {

        
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
        if (InputManager.Instance.IsPrimaryActionReleased() && !hasShot && tutorialEnabled)
        {
            hasShot = true;
        }
    }

    public void CheckDodgeInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !hasDodged && tutorialEnabled)
        {
            hasDodged = true;
        }
    }

    public void CheckCraftInput()
    {
        if (Input.GetKeyDown(KeyCode.C) && !hasCrafted && tutorialEnabled)
        {
            hasCrafted = true;
        }
    }
}
