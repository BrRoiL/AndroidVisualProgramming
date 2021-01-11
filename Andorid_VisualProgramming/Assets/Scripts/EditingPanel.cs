using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditingPanel : MonoBehaviour
{
    [Header("Код")]
    public GameObject codeText;
    public GameObject[] codeButtons;
    [Header("Инструменты")]
    public GameObject toolsText;
    public GameObject[] toolsButtons;
    [Header("Информация")]
    public GameObject informationsText;
    public GameObject[] informationsButtons;
    [Header("Разделительные полосы")]
    public GameObject[] dividingStrip;

    private void Start()
    {
        codeButtons[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(40f, codeText.GetComponent<RectTransform>().anchoredPosition.y - 90f);
        for (int i = 1; i < codeButtons.Length; i++)
        {
            codeButtons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(40f, codeButtons[i - 1].GetComponent<RectTransform>().anchoredPosition.y -  90f);
        }
        dividingStrip[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, codeButtons[codeButtons.Length - 1].GetComponent<RectTransform>().anchoredPosition.y - 90f);

        toolsText.GetComponent<RectTransform>().anchoredPosition = new Vector2(toolsText.GetComponent<RectTransform>().anchoredPosition.x, dividingStrip[0].GetComponent<RectTransform>().anchoredPosition.y -90f);
        toolsButtons[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(40f, toolsText.GetComponent<RectTransform>().anchoredPosition.y - 90f);
        for (int i = 1; i < toolsButtons.Length; i++)
        {
            toolsButtons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(40f, toolsButtons[i - 1].GetComponent<RectTransform>().anchoredPosition.y - 90f);
        }
        dividingStrip[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, toolsButtons[toolsButtons.Length - 1].GetComponent<RectTransform>().anchoredPosition.y - 90f);

        informationsText.GetComponent<RectTransform>().anchoredPosition = new Vector2(informationsText.GetComponent<RectTransform>().anchoredPosition.x, dividingStrip[1].GetComponent<RectTransform>().anchoredPosition.y - 90f);
        informationsButtons[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(40f, informationsText.GetComponent<RectTransform>().anchoredPosition.y - 90f);
        for (int i = 1; i < informationsButtons.Length; i++)
        {
            informationsButtons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(40f, informationsButtons[i - 1].GetComponent<RectTransform>().anchoredPosition.y - 90f);
        }
    }
}
