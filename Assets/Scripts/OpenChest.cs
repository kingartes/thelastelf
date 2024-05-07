using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenChest : MonoBehaviour
{
    public Canvas keyInput;
    public GameObject bossHint;

    public bool canOpen;
    public string hintTextContent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen && Input.GetKeyDown(KeyCode.F))
        {
            openContent();
        }
    }

    public void openContent()
    {
        keyInput.enabled = false;

        TextMeshProUGUI hintContent = bossHint.GetComponent<TextMeshProUGUI>();

        hintContent.text = hintTextContent;

        bossHint.SetActive(true);
        Destroy(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            keyInput.enabled = true;
            canOpen = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            keyInput.enabled = true;
            canOpen = false;
        }
    }

}