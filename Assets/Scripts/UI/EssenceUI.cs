using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssenceUI : MonoBehaviour
{
    [SerializeField]
    private EssenceSystem ES;

    [SerializeField]
    private Image essenceBar;

    Color essenceColor;
    public Color regColor;
    public Color flashColor;
    public float flashTimer;

    private IEnumerator coroutine;

    private void Start()
    {
        essenceColor = essenceBar.color;
    }
    private void Update()
    {
        UpdateBar();
        essenceBar.color = essenceColor;
    }

    private void UpdateBar()
    {
        essenceBar.fillAmount = ES.GetEssenceNormalized();
    }

    public void BarFlash()
    {
        coroutine = ColorChange();
        StopCoroutine(coroutine);
        StartCoroutine(coroutine);
        //StartCoroutine(ColorChange());
    }

    IEnumerator ColorChange()
    {
        essenceColor = regColor;
        essenceColor = flashColor;
        yield return new WaitForSeconds(0.15f);
        essenceColor = regColor;
    }
}
