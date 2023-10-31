using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    public bool isStop = false;//标志位，来判断游戏是否需要被暂停
    public GameObject crosshair;
    public GameObject pauseUI;
    public GameObject popupUI;
    public GameObject promptBox;

    // Start is called before the first frame update
    void Start()
    {
        print(Application.temporaryCachePath);
        crosshair.SetActive(false);
        ShowMouse(true);
        Time.timeScale = 0f;
        pauseUI.SetActive(false);
        popupUI.SetActive(false);
        promptBox.SetActive(false);
    }

    //// Update is called once per frame
    void Update()
    {
        // 按下Esc会显示鼠标
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            StopGame();
        }
    }

    /// <summary>
    /// 隐藏和现实鼠标
    /// </summary>
    /// <param isShow>
    /// true: 显示
    /// false: 隐藏
    /// </param>
    public void ShowMouse(bool isShow)
    {
        if (isShow)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void StopGame()
    {
        if (!isStop)
        {
            pauseUI.SetActive(true);
            isStop = true;
            ShowMouse(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseUI.SetActive(false);
            isStop = false;
            ShowMouse(false);
            Time.timeScale = 1f;
        }
    }
}
