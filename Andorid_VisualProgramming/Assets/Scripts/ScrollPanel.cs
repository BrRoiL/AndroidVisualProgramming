using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollPanel : MonoBehaviour
{
    //Переменные
    [Header("Арифметические опреации")]
    [Tooltip("Картинка триггера")]
    private GameObject triggerImage;
    [Tooltip("Массив модулей арифметических опреаций")]
    public GameObject[] arithmeticOperationsModules;
    [Space]
    [Tooltip("Массив логических операций")]
    public GameObject[] logicalOperationsModules;
    [Space]
    [Tooltip("Массив функциональных операций")]
    public GameObject[] functionOperationsModules;


    private bool arithmeticOperationsTrigger = false;
    private bool logicalOperationsTrigger = false;
    private bool functionOperationsTrigger = false;
    void Start()
    {
        if(arithmeticOperationsModules.Length > 0)
        {
            arithmeticOperationsModules[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(arithmeticOperationsModules[0].GetComponent<RectTransform>().anchoredPosition.x, -50);
            for(int i = 1; i < arithmeticOperationsModules.Length; i++)
            {
                arithmeticOperationsModules[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(arithmeticOperationsModules[i].GetComponent<RectTransform>().anchoredPosition.x, arithmeticOperationsModules[i - 1].GetComponent<RectTransform>().anchoredPosition.y - (arithmeticOperationsModules[i].GetComponent<RectTransform>().sizeDelta.y + 42));
            }
        }
        if (logicalOperationsModules.Length > 0)
        {
            logicalOperationsModules[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(logicalOperationsModules[0].GetComponent<RectTransform>().anchoredPosition.x, -100);
            for (int i = 1; i < logicalOperationsModules.Length; i++)
            {
                logicalOperationsModules[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(logicalOperationsModules[i].GetComponent<RectTransform>().anchoredPosition.x, logicalOperationsModules[i - 1].GetComponent<RectTransform>().anchoredPosition.y - (logicalOperationsModules[i].GetComponent<RectTransform>().sizeDelta.y + 42));
            }
        }
        if (functionOperationsModules.Length > 0)
        {
            functionOperationsModules[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(functionOperationsModules[0].GetComponent<RectTransform>().anchoredPosition.x, -50);
            for (int i = 1; i < functionOperationsModules.Length; i++)
            {
                functionOperationsModules[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(functionOperationsModules[i].GetComponent<RectTransform>().anchoredPosition.x, functionOperationsModules[i - 1].GetComponent<RectTransform>().anchoredPosition.y - (functionOperationsModules[i].GetComponent<RectTransform>().sizeDelta.y + 42));
            }
        }
    }

    
    

    public void ArithmeticOperationsButton()
    {
        triggerImage = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        if (arithmeticOperationsTrigger == false)
        {
            for (int i = 0; i < arithmeticOperationsModules.Length; i++)
            {
                arithmeticOperationsModules[i].gameObject.SetActive(true);
            }
            this.transform.GetChild(1).transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.transform.GetChild(0).transform.GetComponent<RectTransform>().anchoredPosition.x, this.transform.GetChild(0).transform.GetComponent<RectTransform>().anchoredPosition.y - (arithmeticOperationsModules[0].GetComponent<RectTransform>().sizeDelta.y + 42) * arithmeticOperationsModules.Length - 42);
            if (logicalOperationsTrigger == false)
            {
                this.transform.GetChild(2).transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.transform.GetChild(1).transform.GetComponent<RectTransform>().anchoredPosition.x, this.transform.GetChild(1).transform.GetComponent<RectTransform>().anchoredPosition.y - 45);
            }
            else
            {
                this.transform.GetChild(2).transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.transform.GetChild(1).transform.GetComponent<RectTransform>().anchoredPosition.x, this.transform.GetChild(1).transform.GetComponent<RectTransform>().anchoredPosition.y - (logicalOperationsModules[0].GetComponent<RectTransform>().sizeDelta.y + 42) * logicalOperationsModules.Length - 42);
            }
                
        
            TriggerImageUpdate();
            arithmeticOperationsTrigger = true;
        }
        else
        {
            for (int i = 0; i < arithmeticOperationsModules.Length; i++)
            {
                arithmeticOperationsModules[i].gameObject.SetActive(false);
            }
            this.transform.GetChild(1).transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.transform.GetChild(0).transform.GetComponent<RectTransform>().anchoredPosition.x, this.transform.GetChild(0).transform.GetComponent<RectTransform>().anchoredPosition.y - 45);
            if(logicalOperationsTrigger == false)
            {
                this.transform.GetChild(2).transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.transform.GetChild(1).transform.GetComponent<RectTransform>().anchoredPosition.x, this.transform.GetChild(0).transform.GetComponent<RectTransform>().anchoredPosition.y - 90);                       
            }
            else
            {
                this.transform.GetChild(2).transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.transform.GetChild(1).transform.GetComponent<RectTransform>().anchoredPosition.x, this.transform.GetChild(1).transform.GetComponent<RectTransform>().anchoredPosition.y - (logicalOperationsModules[0].GetComponent<RectTransform>().sizeDelta.y + 42) * logicalOperationsModules.Length - 42);
            }
            TriggerImageUpdate();
            arithmeticOperationsTrigger = false;
        }
    }
    public void LogicalOperationsButton()
    {
        triggerImage = this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        if (logicalOperationsTrigger == false)
        {
            for (int i = 0; i < logicalOperationsModules.Length; i++)
            {
                logicalOperationsModules[i].gameObject.SetActive(true);
            }
            this.transform.GetChild(2).transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.transform.GetChild(1).transform.GetComponent<RectTransform>().anchoredPosition.x, this.transform.GetChild(1).transform.GetComponent<RectTransform>().anchoredPosition.y - (logicalOperationsModules[0].GetComponent<RectTransform>().sizeDelta.y + 42) * logicalOperationsModules.Length - 42);

            TriggerImageUpdate();
            logicalOperationsTrigger = true;
        }
        else
        {
            for (int i = 0; i < logicalOperationsModules.Length; i++)
            {
                logicalOperationsModules[i].gameObject.SetActive(false);
            }
            this.transform.GetChild(2).transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.transform.GetChild(1).transform.GetComponent<RectTransform>().anchoredPosition.x, this.transform.GetChild(1).transform.GetComponent<RectTransform>().anchoredPosition.y - 45);

            TriggerImageUpdate();
            logicalOperationsTrigger = false;
        }
    }
    public void FunctionOperationsButton()
    {
        triggerImage = this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject;
        if (functionOperationsTrigger == false)
        {
            for (int i = 0; i < functionOperationsModules.Length; i++)
            {
                functionOperationsModules[i].gameObject.SetActive(true);
            }
            TriggerImageUpdate();
            functionOperationsTrigger = true;
        }
        else
        {
            for (int i = 0; i < functionOperationsModules.Length; i++)
            {
                functionOperationsModules[i].gameObject.SetActive(false);
            }
            TriggerImageUpdate();
            functionOperationsTrigger = false;
        }
    }

    void TriggerImageUpdate()
    {
        if (triggerImage.GetComponent<RectTransform>().transform.eulerAngles == new Vector3(0, 0, 0))
        {
            triggerImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(triggerImage.GetComponent<RectTransform>().anchoredPosition.x, -5);
            triggerImage.GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0, 0, -90);
        }       
        else
        {
            triggerImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(triggerImage.GetComponent<RectTransform>().anchoredPosition.x, 0);
            triggerImage.GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
