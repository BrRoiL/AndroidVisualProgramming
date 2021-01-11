using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentAction : MonoBehaviour
{
    [Tooltip("Мировые настройки")]
    public GameObject WorldSettings;
    [Tooltip("Наследуемый объект")]
    public GameObject parentComponent;
    public GameObject childrenComponent;
    public bool moduleConnect;
    public int vSIndex;

    public List<GameObject> listModulesChild;
    public int oldCountListModulesChild;

     private float variable;
    
    void Update()
    {
        if(childrenComponent != null)
        {
            if (this.GetComponent<ComponentAction>().listModulesChild.Count == 0)
            {
                listModulesChild.Add(childrenComponent);
                oldCountListModulesChild = 1;
            }
            if(this.GetComponent<ComponentAction>().listModulesChild.Count > 0)
            {
                if(childrenComponent.GetComponent<ComponentAction>().listModulesChild.Count > 0)
                {
                    this.GetComponent<ComponentAction>().listModulesChild.Clear();
                    listModulesChild.Add(childrenComponent);
                    for (int i = 1; i <= childrenComponent.GetComponent<ComponentAction>().listModulesChild.Count; i++)
                    {
                        listModulesChild.Add(childrenComponent.GetComponent<ComponentAction>().listModulesChild[i - 1]);
                    }
                }
                if(this.GetComponent<ComponentAction>().listModulesChild.Count > 1 && childrenComponent.GetComponent<ComponentAction>().listModulesChild.Count == 0)
                {
                    this.GetComponent<ComponentAction>().listModulesChild.Clear();
                }


                for (int i = 1; i <= listModulesChild.Count; i++)
                {
                    if (listModulesChild[i - 1].GetComponent<ComponentAction>().GetComponent<RectTransform>().sizeDelta.x < this.GetComponent<RectTransform>().sizeDelta.x)
                    {
                        variable = this.GetComponent<RectTransform>().anchoredPosition.x - ((this.GetComponent<RectTransform>().sizeDelta.x / 2) - (listModulesChild[i - 1].GetComponent<ComponentAction>().GetComponent<RectTransform>().sizeDelta.x / 2));
                    }
                    else
                    {
                        variable = this.GetComponent<RectTransform>().anchoredPosition.x + ((listModulesChild[i - 1].GetComponent<ComponentAction>().GetComponent<RectTransform>().sizeDelta.x / 2) - (this.GetComponent<RectTransform>().sizeDelta.x / 2));
                    }
                    listModulesChild[i - 1].GetComponent<RectTransform>().anchoredPosition = new Vector3(variable, this.GetComponent<RectTransform>().anchoredPosition.y - ((listModulesChild[i - 1].GetComponent<ComponentAction>().GetComponent<RectTransform>().sizeDelta.y / 2) + (this.GetComponent<RectTransform>().sizeDelta.y / 2)) * i + 9f);
                }
            }
            //if (childrenComponent.GetComponent<ComponentAction>().listModulesChild.Count != oldCountListModulesChild)
            //{
            //    if (childrenComponent.GetComponent<ComponentAction>().listModulesChild.Count > 0)
            //    {
            //        if(childrenComponent.GetComponent<ComponentAction>().listModulesChild.Count != 0)
            //        {
            //            for (int i = oldCountListModulesChild; i <= childrenComponent.GetComponent<ComponentAction>().listModulesChild.Count; i++)
            //            {
            //                listModulesChild.Add(childrenComponent.GetComponent<ComponentAction>().listModulesChild[i]); 
            //            }
            //            oldCountListModulesChild = childrenComponent.GetComponent<ComponentAction>().listModulesChild.Count;
            //        }                    
            //    }
            //}
        }
        //if (childrenComponent == null && parentComponent != null && childrenComponent.GetComponent<ComponentAction>().listModulesChild.Count == 0)
        //{
        //    parentComponent.GetComponent<ComponentAction>().oldCountListModulesChild = -1;
        //    if (parentComponent.GetComponent<ComponentAction>().oldCountListModulesChild < - 1)
        //    {
        //        parentComponent.GetComponent<ComponentAction>().oldCountListModulesChild = -1;
        //    }
            
        //}
    }
}
