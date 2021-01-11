using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using System.Globalization;

public class ButtonsFunctions : MonoBehaviour
{
    [Header("Камеры")]
    [Tooltip("Камера для работы с компонентами ВП")]
    public Camera mainCamera;
    public Canvas mainScreen;
    [Tooltip("Камера для работы с компилированным проектом")]
    public Camera cameraCompilation;
    [Space]
    [Header("Рабочая область")]
    [Tooltip("Панель для проводника")]
    public Canvas debugScreen;
    [Space]
    [Header("Массив кода")]
    [Tooltip("Массив модулей визуального программирования")]
    public List<GameObject> vSModules;
    [Space]
    [Header("Анимации")]
    [Tooltip("Объекты для работы с анимацией")]
    public GameObject guide;
    public GameObject guidePanel;
    public GameObject editing;
    public GameObject WorkingScreen;
    [Space]
    [Header("Прочее")]
    [Tooltip("Объекты")]
    public GameObject _mainCamera;
    public GameObject _mainScreen;
    public GameObject _DebugCamera;
    public GameObject _debugScreen;
    public GameObject buttonCreateFolderAndFile;
    public GameObject generateCodeCanvas;
    public GameObject sampleProgammCanvas;
    public GameObject settingsCanvas;
    public GameObject informationCanvas;

    
    public GameObject OldFileOrFolder;
    public GameObject SaveFile;
    public GameObject Folder;

    private float animLength;
    private Animation anim;
    private bool triggerGuide;
    private bool triggerEditing;
    private bool triggerButtonCreateFolderAndFile;
    private TouchScreenKeyboard keyboard;
    private int numFile = 1;
    private int numFolder = 1;

    [Space]
    public bool Activate;

    public void ButtonPlay()
    {
        anim = guide.GetComponent<Animation>();  
        mainCamera.gameObject.SetActive(false);
        cameraCompilation.gameObject.SetActive(true);
        mainScreen.gameObject.SetActive(false);
        debugScreen.gameObject.SetActive(true);
        anim["Guide"].time = 0;
        Activate = true;
    }

    public void ButtonGuide()
    {
        if(triggerEditing == true)
        {
            ButtonEditing();
        }
        
        anim = guide.GetComponent<Animation>();         
        animLength = anim.clip.length;
        if ((triggerGuide == true && triggerEditing == true) || (triggerGuide == true && triggerEditing == false))
        {
            if(!anim.IsPlaying("Guide"))
            {
                anim["Guide"].speed = -3;
                anim["Guide"].time = anim.clip.length;
                anim.Play();
                _mainScreen.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Button>().enabled = true;
                _mainScreen.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(255f, 255f, 255f, 1f);
                _mainScreen.transform.GetChild(1).gameObject.SetActive(true);
                _mainCamera.GetComponent<MultiTouchCamera>().enabled = true;
                triggerGuide = false;

                triggerButtonCreateFolderAndFile = false;
                buttonCreateFolderAndFile.transform.GetChild(0).GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 0, 0);
                buttonCreateFolderAndFile.transform.GetChild(1).gameObject.SetActive(false);
                buttonCreateFolderAndFile.transform.GetChild(2).gameObject.SetActive(false);
            }           
        }
        else
        {
            if (!anim.IsPlaying("Guide"))
            {
                anim["Guide"].speed = 2;
                anim["Guide"].time = 0;
                anim.Play();
                _mainScreen.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Button>().enabled = false;
                _mainScreen.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.25f);
                _mainScreen.transform.GetChild(1).gameObject.SetActive(false);
                _mainCamera.GetComponent<MultiTouchCamera>().enabled = false;
                triggerGuide = true;
            }             
        }
    }

    public void ButtonEditing()
    {
        if (triggerGuide == true)
        {
            ButtonGuide();
        }
        anim = editing.GetComponent<Animation>();
        animLength = anim.clip.length;
        if ((triggerEditing == true && triggerGuide == true) || (triggerEditing == true && triggerGuide == false))
        {
            if (!anim.IsPlaying("Editing"))
            {
                anim["Editing"].speed = -3;
                anim["Editing"].time = anim.clip.length;
                anim.Play();
                _mainScreen.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Button>().enabled = true;
                _mainScreen.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(255f, 255f, 255f, 1f);
                _mainScreen.transform.GetChild(1).gameObject.SetActive(true);
                _mainCamera.GetComponent<MultiTouchCamera>().enabled = true;
                triggerEditing = false;
            }

        }
        else
        {
            if (!anim.IsPlaying("Editing"))
            {
                anim["Editing"].speed = 2;
                anim["Editing"].time = 0;
                anim.Play();
                _mainScreen.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Button>().enabled = false;
                _mainScreen.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.25f);
                _mainScreen.transform.GetChild(1).gameObject.SetActive(false);
                _mainCamera.GetComponent<MultiTouchCamera>().enabled = false;
                triggerEditing = true;
            }
        }
    }

    public void ButtonBack()
    {
        mainCamera.gameObject.SetActive(true);
        cameraCompilation.gameObject.SetActive(false);
        mainScreen.gameObject.SetActive(true);
        debugScreen.gameObject.SetActive(false);
        Activate = false;
    }

    public void Keyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    public void Reload()
    {
        debugScreen.gameObject.SetActive(false);
        debugScreen.gameObject.SetActive(true);

        System.Threading.Thread.Sleep(100);
    }

    public void ButtonGenerateCodeCanvas()
    {
        WorkingScreen.transform.GetChild(0).gameObject.SetActive(false);
        _mainScreen.gameObject.SetActive(false);
        generateCodeCanvas.gameObject.SetActive(true);
        ButtonEditing();
        _mainCamera.GetComponent<MultiTouchCamera>().enabled = false;
    }

    public void ButtonSampleProgammCanvas()
    {
        WorkingScreen.transform.GetChild(0).gameObject.SetActive(false);
        _mainScreen.gameObject.SetActive(false);
        sampleProgammCanvas.gameObject.SetActive(true);
        ButtonEditing();
        _mainCamera.GetComponent<MultiTouchCamera>().enabled = false;
    }
    public void ButtonSettingsCanvas()
    {
        WorkingScreen.transform.GetChild(0).gameObject.SetActive(false);
        _mainScreen.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(true);
        ButtonEditing();
        _mainCamera.GetComponent<MultiTouchCamera>().enabled = false;
    }
    public void ButtonInformationCanvas()
    {
        WorkingScreen.transform.GetChild(0).gameObject.SetActive(false);
        _mainScreen.gameObject.SetActive(false);
        informationCanvas.gameObject.SetActive(true);
        ButtonEditing();
        _mainCamera.GetComponent<MultiTouchCamera>().enabled = false;
    }

    public void ButtonCancel()
    {
        _mainCamera.GetComponent<MultiTouchCamera>().enabled = true;
        WorkingScreen.transform.GetChild(0).gameObject.SetActive(true);
        _mainScreen.gameObject.SetActive(true);
        if(generateCodeCanvas.gameObject.activeInHierarchy == true)
        {
            generateCodeCanvas.gameObject.SetActive(false);
        }
        if (sampleProgammCanvas.gameObject.activeInHierarchy == true)
        {
            sampleProgammCanvas.gameObject.SetActive(false);
        }
        if (settingsCanvas.gameObject.activeInHierarchy == true)
        {
            settingsCanvas.gameObject.SetActive(false);
        }
        if (informationCanvas.gameObject.activeInHierarchy == true)
        {
            informationCanvas.gameObject.SetActive(false);
        }
        Activate = false;
    }

    public void ButtonCreateFolderAndFile()
    {
        anim = buttonCreateFolderAndFile.GetComponent<Animation>();
        animLength = anim.clip.length;
        if (triggerButtonCreateFolderAndFile == true)
        {
            if (!anim.IsPlaying("ButtonCreateFolderAndFile"))
            {
                anim["ButtonCreateFolderAndFile"].speed = -3;
                anim["ButtonCreateFolderAndFile"].time = anim.clip.length;
                anim.Play();

                triggerButtonCreateFolderAndFile = false;
            }

        }
        else
        {
            if (!anim.IsPlaying("ButtonCreateFolderAndFile"))
            {
                anim["ButtonCreateFolderAndFile"].speed = 2;
                anim["ButtonCreateFolderAndFile"].time = 0;
                anim.Play();

                triggerButtonCreateFolderAndFile = true;
            }
        }
    }

    public void ButtonCreateNewFile()
    {
        if(numFile < 5)
        {
            string nameFile = "FileNumber" + numFile;
            GameObject NewFile;
            GameObject ListSafeFileAndFolder = guide.transform.GetChild(6).gameObject;
            NewFile = Instantiate(SaveFile, OldFileOrFolder.GetComponent<RectTransform>().anchoredPosition - new Vector2(0f, 150f), new Quaternion(0, 0, 0, 0));
            NewFile.transform.SetParent(ListSafeFileAndFolder.transform);
            NewFile.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            NewFile.GetComponent<RectTransform>().anchoredPosition = OldFileOrFolder.GetComponent<RectTransform>().anchoredPosition - new Vector2(0, 150);
            NewFile.transform.GetChild(2).transform.GetComponent<TextMeshProUGUI>().text = System.DateTime.Now.ToString() + " " + "0 Кб";
            NewFile.transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>().text = nameFile;
            OldFileOrFolder = NewFile;
            numFile++;

            triggerButtonCreateFolderAndFile = false;
            buttonCreateFolderAndFile.transform.GetChild(0).GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 0, 0);
            buttonCreateFolderAndFile.transform.GetChild(1).gameObject.SetActive(false);
            buttonCreateFolderAndFile.transform.GetChild(2).gameObject.SetActive(false);
        }
        
    }

    [System.Obsolete]
    public void ButtonCreateNewFolder()
    {
        if(numFolder < 5)
        {
            string nameFolder = "FolderNumber" + numFolder;
            GameObject NewFoler;
            GameObject ListSafeFileAndFolder = guide.transform.GetChild(6).gameObject;
            NewFoler = Instantiate(Folder, OldFileOrFolder.GetComponent<RectTransform>().anchoredPosition - new Vector2(0f, 150f), new Quaternion(0, 0, 0, 0));
            NewFoler.transform.SetParent(ListSafeFileAndFolder.transform);
            NewFoler.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            NewFoler.GetComponent<RectTransform>().anchoredPosition = OldFileOrFolder.GetComponent<RectTransform>().anchoredPosition - new Vector2(0, 150);
            NewFoler.transform.GetChild(2).transform.GetComponent<TextMeshProUGUI>().text = System.DateTime.Now.ToString() + " " + "0 Кб";       
            NewFoler.transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>().text = nameFolder;
            OldFileOrFolder = NewFoler;
            numFolder++;

            triggerButtonCreateFolderAndFile = false;
            buttonCreateFolderAndFile.transform.GetChild(0).GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 0, 0);
            buttonCreateFolderAndFile.transform.GetChild(1).gameObject.SetActive(false);
            buttonCreateFolderAndFile.transform.GetChild(2).gameObject.SetActive(false);
        }
        
    }
}
