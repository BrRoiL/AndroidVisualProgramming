using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VS_Begin : MonoBehaviour
{
    public void StartLoadModules()
    {
        this.GetComponent<ComponentAction>().WorldSettings.GetComponent<ButtonsFunctions>()._debugScreen.transform.GetChild(0).GetComponent<StartProgramm>().vS_Modules.Clear();
        if (this.GetComponent<ComponentAction>().WorldSettings.GetComponent<ButtonsFunctions>().Activate == true)
        {
            if (this.GetComponent<ComponentAction>().listModulesChild.Count > 0)
            {
                for (int i = 1; i <= this.GetComponent<ComponentAction>().listModulesChild.Count; i++)
                {
                    this.GetComponent<ComponentAction>().WorldSettings.GetComponent<ButtonsFunctions>()._debugScreen.transform.GetChild(0).GetComponent<StartProgramm>().vS_Modules.Add(this.GetComponent<ComponentAction>().listModulesChild[i - 1]);
                }
            }
            
        }
    }
}
