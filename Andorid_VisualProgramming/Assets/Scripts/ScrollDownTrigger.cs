using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDownTrigger : MonoBehaviour
{
    public bool scriptActivate = false;
    public GameObject scrollPanel;
    public GameObject scrollPointer;

    private float scrollPanelY;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptActivate == true)
        {
            scrollPointer.SetActive(false);
            if (scrollPanel.transform.localPosition.y <= -660f)
            {
                scrollPanel.transform.localPosition = new Vector3(scrollPanel.transform.localPosition.x, scrollPanel.transform.localPosition.y + 50f);
            }
        }
        else
        {
            if (scrollPanel.transform.localPosition.y >= -1300f)
            {
                scrollPanel.transform.localPosition = new Vector3(scrollPanel.transform.localPosition.x, scrollPanel.transform.localPosition.y - 50f);
            }
            else
            {
                scrollPointer.SetActive(true);
            }
        }
    }
}
