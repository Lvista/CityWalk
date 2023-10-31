using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject mainlogic;
    private GameObject thisUI;
    private void Start()
    {
        thisUI = GameObject.Find("PauseUI");
        mainlogic = GameObject.Find("-----MainLogic---------");
    }
    public void Continue()
    {
        mainlogic.GetComponent<MainLogic>().StopGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
