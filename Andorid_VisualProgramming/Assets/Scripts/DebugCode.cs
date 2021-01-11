using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugCode : MonoBehaviour
{
    public GameObject WorldSettings;
    public void CreateProgramm()
    {
        this.GetComponent<StartProgramm>().StartCode();
    }
}
