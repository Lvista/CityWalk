using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemoveShowB1: MonoBehaviour
{
    private bool b1IsShow = true;
    public GameObject building1;
    private TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RemoveB1()
    {
        b1IsShow = !b1IsShow;
        building1.SetActive(b1IsShow);
        if (b1IsShow)
        {
            textMeshProUGUI.text = "Hide B1";
        }
        else
        {
            textMeshProUGUI.text = "Show B1";
        }
    }
}
