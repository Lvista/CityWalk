using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMode : MonoBehaviour
{
    public bool testModeFlag = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TeleToA1()
    {
        GameObject.Find("Teleport").GetComponent<Teleport>().Tele(0);
    }
    public void ChangeMode(bool flag)
    {
        testModeFlag = flag;
    }
}
