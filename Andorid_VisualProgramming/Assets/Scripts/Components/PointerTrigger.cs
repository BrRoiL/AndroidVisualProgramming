using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerTrigger : MonoBehaviour
{
    private bool UpdateActivate;
    private GameObject collid;
    private GameObject component = null;

    void Start()
    {
        UpdateActivate = true;
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            this.gameObject.transform.parent.transform.GetChild(3).transform.gameObject.SetActive(true);
            if (collid != null && collid.transform.tag != "BG")
            {
                if (UpdateActivate == true)
                {
                    if (collid.gameObject.tag == "PointerTrigger" && collid.transform.parent.gameObject.tag == "Component")
                    {

                        collid.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);

                        if (this.transform.parent.GetSiblingIndex() > collid.transform.parent.GetSiblingIndex())
                        {
                            this.transform.parent.SetSiblingIndex(collid.transform.parent.GetSiblingIndex());
                        }

                        if (collid.transform.parent.tag == "Component")
                        {
                            collid.transform.parent.GetComponent<ComponentAction>().childrenComponent = this.transform.parent.gameObject;
                            component = collid;
                            if (this.transform.parent.transform.GetComponent<ComponentAction>().moduleConnect == false)
                            {
                                this.transform.parent.transform.GetComponent<ComponentAction>().parentComponent = collid.transform.parent.gameObject;
                                collid.transform.parent.transform.GetComponent<ComponentAction>().childrenComponent = this.transform.parent.gameObject;
                                if(collid.transform.parent.transform.GetComponent<ComponentAction>().vSIndex == -3)
                                {
                                    this.transform.parent.transform.GetComponent<ComponentAction>().vSIndex = -3;
                                }
                                else
                                {
                                    this.transform.parent.transform.GetComponent<ComponentAction>().vSIndex = collid.transform.parent.transform.GetComponent<ComponentAction>().vSIndex + 1;
                                }
                                this.transform.parent.transform.GetComponent<ComponentAction>().moduleConnect = true;
                            }
                            else
                            {
                                this.transform.parent.transform.GetComponent<ComponentAction>().parentComponent = collid.transform.parent.gameObject;
                            }
                        }                  

                        UpdateActivate = false;
                    }
                }
            }                   
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (Input.GetMouseButton(0))
        {
            if(col.gameObject.tag == "PointerTrigger" && col.transform.parent.gameObject.tag == "Component")
            {
                if (col.transform.parent.GetComponent<ComponentAction>().childrenComponent == null)
                {
                    col.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
                    UpdateActivate = true;
                }
                
                //this.gameObject.transform.parent.transform.GetChild(3).transform.gameObject.SetActive(false);
            }
        }      
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "PointerTrigger" && col.transform.parent.gameObject.tag == "Component")
        {
            col.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
            UpdateActivate = false;
        }
        //col.transform.parent.gameObject.GetComponent<ComponentAction>().moduleConnect = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        collid = col.gameObject;
        if (collid.gameObject.tag == "PointerTrigger" && collid.transform.parent.gameObject.tag == "Component")
        {
          
        }
    }
}
