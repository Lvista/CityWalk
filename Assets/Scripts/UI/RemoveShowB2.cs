using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemoveShowB2: MonoBehaviour
{
    private bool b2IsShow = true;
    public GameObject building2;
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
    public void RemoveB2()
    {
        b2IsShow = !b2IsShow;
        building2.SetActive(b2IsShow);
        if (b2IsShow)
        {
            textMeshProUGUI.text = "Hide B2";
        }
        else
        {
            textMeshProUGUI.text = "Show B2";
        }
    }
}
