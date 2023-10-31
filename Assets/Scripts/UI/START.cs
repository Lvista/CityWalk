using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class START : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject StartUI;
    // Start is called before the first frame update
    public void StartGame()
    {
        crosshair.SetActive(true);
        StartUI.SetActive(false);
        Time.timeScale = 1f;
        // 隐藏鼠标
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
}
