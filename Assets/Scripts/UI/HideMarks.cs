using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideShowMarks : MonoBehaviour
{
    private bool marksIsShow = true;
    public GameObject marks;
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
    public void HideMarks()
    {
        marksIsShow = !marksIsShow;
        marks.SetActive(marksIsShow);
        if (marksIsShow)
        {
            textMeshProUGUI.text = "Hide Marks";
        }
        else
        {
            textMeshProUGUI.text = "Show Marks";
        }
    }
}
