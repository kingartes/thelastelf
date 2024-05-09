using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public GameObject[] OpeningItems;
    public GameObject OpeningFadeAway;
    public GameObject OpeningBG;
    public GameObject TP;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpeningScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OpeningScene()
    {
        OpeningItems[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        OpeningItems[1].SetActive(true);
        yield return new WaitForSeconds(2f);
        OpeningItems[2].SetActive(true);
        yield return new WaitForSeconds(2f);
        OpeningItems[3].SetActive(true);

        yield return new WaitForSeconds(3f);
        OpeningItems[4].SetActive(true);
        yield return new WaitForSeconds(2f);
        OpeningItems[5].SetActive(true);
        foreach (GameObject item in OpeningItems) { item.SetActive(false); }
        yield return new WaitForSeconds(1f);
        OpeningBG.SetActive(false);

        OpeningFadeAway.SetActive(true);
        TP.SetActive(true);
    }
}
