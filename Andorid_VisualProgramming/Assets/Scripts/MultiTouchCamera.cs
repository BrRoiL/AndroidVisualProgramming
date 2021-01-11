using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiTouchCamera : MonoBehaviour
{
    //Переменные для нажатия на экран
    Vector3 touchStart; //Точка начальных координат нажатия
    Vector3 clickPoint;

    //Переменные для камеры
    [Header("Настройки камеры")]
    [Tooltip("Максимальная выстота камеры")]
    public float maxZoom;
    [Tooltip("Минимальная выстота камеры")]
    public float minZoom;
    [Tooltip("Скорость изменения масштаба камеры")]
    public float sensitivity;
    private RaycastHit2D[] rayHit;

    [Header("Список компонентов визуального программирования")]
    public GameObject[] prefabsComnponents;

    [Header("Прочее")]
    public GameObject canavas;
    public GameObject createdComponents;
    public GameObject scrollTrigger;
    public GameObject TrashCan;
    public GameObject StartCode;


    private bool activityScrollWindow;
    public bool notActivityMovingCamera;
    private bool dragPoint = false;
    private int indexLayer;
    private int numberComponents;
    private GameObject gameobjectTemporary;
    private GameObject ray2DTemporary;
    private GameObject triggerObject;
    private Vector2 changedPositionLength;
    private Vector2 changedPositionLengthTemprory;
    private Vector2 positionsTemporary;
    private Vector2 positionsTemporaryMouse;
    private Vector2 oldPositionsMouse;
    private Vector2 positionsTemporaryComponent;
    private Vector2 touchUpdate;

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //Проверка области нажатия
        {
            StartingPosition();
            LayerCheck();
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.touchCount == 2) //Изменение зума камеры
            {
                //Touch touchZero = Input.GetTouch(0);
                //Touch touchOne = Input.GetTouch(1);

                //Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                //Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                //float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                //float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                //float difference = currentMagnitude - prevMagnitude;
                //ZoomCamera(difference * 0.01f);
            }
            else if (notActivityMovingCamera == false) //Перемещение камеры с ограниченной областью
            {
                if (rayHit[0].transform.gameObject.tag == "BG") //Перемещение всплывающего окна
                {
                    Vector3 direction = touchStart - GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
                    GetComponent<Camera>().transform.position += direction;
                }
                if (this.transform.position.x < -10000)
                {
                    this.transform.position = new Vector3(-10000, this.transform.position.y, this.transform.position.z);
                }
                if (this.transform.position.x > 10000)
                {
                    this.transform.position = new Vector3(10000, this.transform.position.y, this.transform.position.z);
                }
                if (this.transform.position.y < -10000)
                {
                    this.transform.position = new Vector3(this.transform.position.x, -10000, this.transform.position.z);
                }
                if (this.transform.position.y > 10000)
                {
                    this.transform.position = new Vector3(this.transform.position.x, 10000, this.transform.position.z);
                }
            }

            if (notActivityMovingCamera == true)
            {
                UpdatePosition();

                if (activityScrollWindow == true)
                {
                    if (dragPoint == true && gameobjectTemporary.transform.tag == "ComponentCreate") //Перемещение создающего компонента из всплывающего окна
                    {
                        gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition = new Vector2(touchUpdate.x, touchUpdate.y);

                        if (gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition.x > 480f)
                        {
                            triggerObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-40f, triggerObject.GetComponent<RectTransform>().anchoredPosition.y);
                        }
                        if (gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition.x < 100f)
                        {
                            triggerObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(480f, triggerObject.GetComponent<RectTransform>().anchoredPosition.y);
                        }
                    }
                    if (dragPoint == false) //Перемещение всплывающего окна ScrollTrigger
                    {
                        triggerObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(touchUpdate.x, triggerObject.GetComponent<RectTransform>().anchoredPosition.y);

                        if (triggerObject.GetComponent<RectTransform>().anchoredPosition.x > 480f)
                        {
                            triggerObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(480f, triggerObject.GetComponent<RectTransform>().anchoredPosition.y);
                        }
                        if (triggerObject.GetComponent<RectTransform>().anchoredPosition.x < -40f)
                        {
                            triggerObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-40f, triggerObject.GetComponent<RectTransform>().anchoredPosition.y);
                        }
                    }
                }
                if (activityScrollWindow == false)
                {
                    if (dragPoint == true && gameobjectTemporary.transform.tag == "Component") //Перемещение компонента
                    {
                        if(gameobjectTemporary.transform.name != "StartCode")
                        {
                            TrashCan.SetActive(true);
                        }

                        ///////////////////////
                        positionsTemporaryMouse = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition) / 2;
                        changedPositionLength = touchStart;
                        //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)));
                        gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition = positionsTemporaryMouse + new Vector2(5000f, 5000f);

                        ///////////////////////
                        if (gameobjectTemporary.GetComponent<ComponentAction>().childrenComponent != null)
                        {
                            for (int i = 0; i < gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild.Count; i++)
                            {
                                float lenDif;
                                if(gameobjectTemporary.GetComponent<RectTransform>().sizeDelta.x > gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild[i].GetComponent<RectTransform>().sizeDelta.x)
                                {
                                    lenDif = Mathf.Abs(gameobjectTemporary.GetComponent<RectTransform>().sizeDelta.x - gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild[i].GetComponent<RectTransform>().sizeDelta.x);
                                }
                                else
                                {
                                    lenDif = Mathf.Abs(gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild[i].GetComponent<RectTransform>().sizeDelta.x - gameobjectTemporary.GetComponent<RectTransform>().sizeDelta.x);
                                }
                                if(i == 0)
                                {
                                    gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition.x + lenDif / 2, gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition.y - gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild[i].GetComponent<RectTransform>().sizeDelta.y + 9);
                                }
                                else
                                {
                                    gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition.x + lenDif / 2, gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild[i - 1].GetComponent<RectTransform>().anchoredPosition.y - gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild[i].GetComponent<RectTransform>().sizeDelta.y + 9);
                                }
                                if (gameobjectTemporary.name != "StartCode")
                                {
                                    gameobjectTemporary.transform.GetChild(3).gameObject.SetActive(false);
                                    gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild[i].transform.GetChild(3).gameObject.SetActive(false);
                                }
                                 
                            }
                        }
                        else
                        {
                            if(gameobjectTemporary.name != "StartCode")
                            {
                                gameobjectTemporary.GetComponent<ComponentAction>().vSIndex = -2;
                                gameobjectTemporary.GetComponent<ComponentAction>().moduleConnect = false;
                                gameobjectTemporary.transform.GetChild(3).gameObject.SetActive(false);
                            }
                            
                        }

                        if (positionsTemporaryMouse.x > -540 && positionsTemporaryMouse.x < -340 && positionsTemporaryMouse.y < -760 && positionsTemporaryMouse.y > -1920)
                        {
                            TrashCan.GetComponent<RectTransform>().localScale = new Vector2(1.2f, 1.2f);
                        }
                        else
                        {
                            TrashCan.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
                        }
                        
                        indexLayer = gameobjectTemporary.transform.GetSiblingIndex();
                        gameobjectTemporary.transform.SetSiblingIndex(numberComponents);
                        oldPositionsMouse = positionsTemporaryMouse;
                    }
                    
                    if (gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition.x < gameobjectTemporary.GetComponent<RectTransform>().sizeDelta.x / 2)
                    {
                        gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameobjectTemporary.GetComponent<RectTransform>().sizeDelta.x / 2, gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition.y);
                    }
                    if (gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition.x > 10000 - gameobjectTemporary.GetComponent<RectTransform>().sizeDelta.x / 2)
                    {
                        gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition = new Vector2(10000 - gameobjectTemporary.GetComponent<RectTransform>().sizeDelta.x / 2, gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition.y);
                    }
                    if (gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition.y < gameobjectTemporary.GetComponent<RectTransform>().sizeDelta.y / 2)
                    {
                        gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition.x, gameobjectTemporary.GetComponent<RectTransform>().sizeDelta.y / 2);
                    }
                    if (gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition.y > 10000 - gameobjectTemporary.GetComponent<RectTransform>().sizeDelta.y / 2)
                    {
                        gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameobjectTemporary.GetComponent<RectTransform>().anchoredPosition.x, 10000 - gameobjectTemporary.GetComponent<RectTransform>().sizeDelta.y / 2);
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (notActivityMovingCamera == true)
            {
                if (activityScrollWindow == true) //Автоматическое перемещение по краям всплывающего окна ScrollTrigger
                {
                    if (triggerObject.GetComponent<RectTransform>().anchoredPosition.x < 220)
                    {
                        triggerObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-40, triggerObject.GetComponent<RectTransform>().anchoredPosition.y);
                        activityScrollWindow = false;
                    }
                    else
                    {
                        triggerObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(480f, triggerObject.GetComponent<RectTransform>().anchoredPosition.y);
                        activityScrollWindow = true;
                    }
                }
                if (dragPoint == true && gameobjectTemporary.transform.tag == "ComponentCreate") //Удаление компонентов при создании
                {
                    StartingPosition();
                  
                    if (rayHit[1].transform.gameObject.name == "Background")
                    {
                        gameobjectTemporary.transform.SetParent(createdComponents.transform);
                        gameobjectTemporary.transform.SetSiblingIndex(0);
                        gameobjectTemporary.transform.tag = "Component";
                        gameobjectTemporary.transform.GetChild(5).transform.GetComponent<PointerTrigger>().enabled = true;
                        gameobjectTemporary.transform.GetChild(5).transform.GetComponent<PointerTrigger>().Update(); //???
                    }

                    if (rayHit[0].transform.gameObject.tag == "ComponentCreate" || rayHit[1].transform.gameObject.name == "ScrollPanel" || rayHit[1].transform.gameObject.name == "BackgroundFon")
                    {
                        Destroy(gameobjectTemporary);
                    }
                }
                
                dragPoint = false;
                notActivityMovingCamera = false;
                positionsTemporaryMouse = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition) / 2;
                if (rayHit[0].transform.gameObject.tag == "Component" && rayHit[0].transform.gameObject.name != "StartCode" && positionsTemporaryMouse.x > -540 && positionsTemporaryMouse.x < -340 && positionsTemporaryMouse.y < -760 && positionsTemporaryMouse.y > -1920)
                {
                    if (gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild.Count > 0)
                    {
                        for (int i = gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild.Count; i >= 1; i--)
                        {
                            Destroy(gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild[i - 1]);
                        }
                        Destroy(gameobjectTemporary);
                    }                     
                }
                    TrashCan.SetActive(false);
            }
            if (dragPoint == true && gameobjectTemporary.transform.tag == "Component") //Перемещение компонента
            {
                gameobjectTemporary.transform.SetSiblingIndex(indexLayer - 1);             
            }
        }
    }

    void ZoomCamera(float increment) //Функция зуммирования
    {
        GetComponent<Camera>().orthographicSize = Mathf.Clamp(GetComponent<Camera>().orthographicSize - increment * sensitivity, minZoom, maxZoom);
    }

    void StartingPosition() //Начальная позиция нажатия
    {
        touchStart = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        rayHit = Physics2D.RaycastAll(touchStart, Vector2.zero);
    }

    void UpdatePosition() //Начальная позиция нажатия
    {
        //touchUpdate = GetComponent<Camera>().WorldToScreenPoint(gameobjectTemporary.transform.position);
        touchUpdate = Input.mousePosition;
        //Debug.Log(touchUpdate);
    }

    void LayerCheck() //Проверка слоев
    {
        if (rayHit[0].transform.gameObject.tag == "TriggerLayer") //Перемещение всплывающего окна
        {
            notActivityMovingCamera = true;
            activityScrollWindow = true;
            triggerObject = rayHit[0].transform.gameObject;
        }

        if (rayHit[0].transform.gameObject.tag == "ComponentCreate") //Создание копии компонента
        {
            dragPoint = true;
            notActivityMovingCamera = true;
            ray2DTemporary = rayHit[0].transform.gameObject;
            positionsTemporary = ray2DTemporary.GetComponent<RectTransform>().anchoredPosition;
            gameobjectTemporary = Instantiate(ray2DTemporary, new Vector3(ray2DTemporary.transform.localPosition.x, ray2DTemporary.transform.localPosition.y, -1), ray2DTemporary.transform.rotation);
            gameobjectTemporary.transform.SetParent(canavas.transform);
            gameobjectTemporary.transform.localScale = new Vector3(1, 1, 1);
            numberComponents++;
        }

        if (rayHit[0].transform.gameObject.tag == "BG") //Авто убирание всплывающего окна
        {
            if (scrollTrigger.GetComponent<RectTransform>().anchoredPosition.x == 520f)
            {
                triggerObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, triggerObject.GetComponent<RectTransform>().anchoredPosition.y);
            }
        }
        if (rayHit[0].transform.gameObject.tag == "Component") //Перемещение созданных компонентов
        {
            dragPoint = true;
            notActivityMovingCamera = true;
            gameobjectTemporary = rayHit[0].transform.gameObject;

            if (gameobjectTemporary != null)
            {
                if (gameobjectTemporary.GetComponent<ComponentAction>().parentComponent != null && gameobjectTemporary.transform.tag == "Component")
                {
                    gameobjectTemporary.GetComponent<ComponentAction>().parentComponent.GetComponent<ComponentAction>().listModulesChild.Clear();                             
                    //gameobjectTemporary.GetComponent<ComponentAction>().parentComponent.GetComponent<ComponentAction>().oldCountListModulesChild = 0;
                    gameobjectTemporary.GetComponent<ComponentAction>().parentComponent.GetComponent<ComponentAction>().childrenComponent = null;
                    gameobjectTemporary.GetComponent<ComponentAction>().parentComponent = null;
                    gameobjectTemporary.transform.GetChild(3).gameObject.SetActive(true);
                    gameobjectTemporary.GetComponent<ComponentAction>().oldCountListModulesChild = gameobjectTemporary.GetComponent<ComponentAction>().listModulesChild.Count;
                    gameobjectTemporary.GetComponent<ComponentAction>().vSIndex = -3;

                }
            }
        }       
    }
}