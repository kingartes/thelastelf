using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    public Renderer MatRenderer;
    public Color startColor;
    public Color endColor;


    private float Timer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ChangeTransparency(bool isStart)
    {
        if (isStart)
            StartCoroutine(IncTransparency());
        else
            StartCoroutine(DecTransparency());
    }

    IEnumerator IncTransparency()
    {
        Timer = 0f;

        while (Timer < 2f)
        {

            MatRenderer.materials[0].color = Color.Lerp(startColor, endColor, Timer / 2f);
            MatRenderer.materials[1].color = Color.Lerp(startColor, endColor, Timer / 2f);


            Timer += Time.deltaTime;
            yield return null;
        }

    }

    IEnumerator DecTransparency()
    {
        Timer = 0f;

        while (Timer < 2f)
        {

            MatRenderer.materials[0].color = Color.Lerp(endColor, startColor, Timer / 2f);
            MatRenderer.materials[1].color = Color.Lerp(endColor, startColor, Timer / 2f);


            Timer += Time.deltaTime;
            yield return null;
        }

    }
}
