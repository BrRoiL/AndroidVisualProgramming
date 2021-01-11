using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public float ScreenHeight;
    public float ScreenWidth;

    void Start()
    {
        ScreenHeight = Screen.height;
        ScreenWidth = Screen.width;
    }
}
