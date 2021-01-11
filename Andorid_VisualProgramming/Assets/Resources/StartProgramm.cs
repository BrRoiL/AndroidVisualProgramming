using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartProgramm : MonoBehaviour
{
    public List<GameObject> vS_Modules;

    private float Value;
    public void StartCode()
    {
        Value = 0;
        for (int i = 1; i <= vS_Modules.Count; i++)
       {
            if (vS_Modules[i - 1].GetComponent<VS_Modules>().Text == "+")
            {
                i++;
                Value = Addition(Value, i);
            }
            else if (vS_Modules[i - 1].GetComponent<VS_Modules>().Text == "-")
            {
                i++;
                Value = Subtraction(Value, i);
            }
            else if (vS_Modules[i - 1].GetComponent<VS_Modules>().Text == "*")
            {
                i++;
                Value = Multiplication(Value, i);
            }
            else if (vS_Modules[i - 1].GetComponent<VS_Modules>().Text == "/")
            {
                i++;
                Value = Division(Value, i);
            }
            else
            {
                Value += int.Parse(vS_Modules[i - 1].GetComponent<VS_Modules>().Text);
            }
        }
        this.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Value.ToString();
    }
        
    float Addition(float Value, int i)
    {
        Value += int.Parse(vS_Modules[i - 1].GetComponent<VS_Modules>().Text);
        return Value;
    }
        
    float Subtraction(float Value, int i)
    {
        Value -= int.Parse(vS_Modules[i - 1].GetComponent<VS_Modules>().Text);
        return Value;
    }
        
    float Multiplication(float Value, int i)
    {
        Value *= int.Parse(vS_Modules[i - 1].GetComponent<VS_Modules>().Text);
        return Value;
    }
        
    float Division(float Value, int i)
    {        Value /= int.Parse(vS_Modules[i - 1].GetComponent<VS_Modules>().Text);
        return Value;
    }
}
