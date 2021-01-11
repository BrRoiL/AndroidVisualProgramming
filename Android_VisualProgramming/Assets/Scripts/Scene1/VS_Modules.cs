using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VS_Modules : MonoBehaviour
{
    public string Text;
    //public void VS_Update()
    //{
    //    if (this.GetComponent<ComponentAction>().WorldSettings.GetComponent<ButtonsFunctions>().Activate == true)
    //    {
    //        //int.TryParse(this.transform.GetChild(6).GetComponent<TMP_InputField>().text, out this.GetComponent<ComponentAction>().WorldSettings.GetComponent<VS_Begin>().ValueCodeAll);
    //        this.GetComponent<ComponentAction>().WorldSettings.GetComponent<ButtonsFunctions>()._debugScreen.transform.GetChild(0).GetComponent<DebugCode>().ModulesVSCode += Text;
    //    }
    //}
    private void Update()
    {
        if(name == "Value(Clone)")
        {
            Text = this.transform.GetChild(6).GetComponent<TMP_InputField>().text;
        }
    }
}
