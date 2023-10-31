using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagement : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject popupUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close(GameObject ui)
    {
        ui.SetActive(false);
    }
    public void Open(GameObject ui)
    {
        ui.SetActive(true);
    }
}
