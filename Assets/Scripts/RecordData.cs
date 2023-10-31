using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RecordData : MonoBehaviour
{
    public int testNum = 0;
    public bool testModeFlag = false;
    public Camera mycamera;
    public Transform tarPosition; //目标位置
    public Transform anchor;
    private string msg;
    private float deltaTime = 0f;
    private int tarPosiNum = 1;
    private int playerPosi = 0;
    private string promptBoxText;
    public GameObject promptBoxText_G;
    private TMP_Text textMeshPro;

    //public AudioClip bgaudioClip;
    private AudioSource myaudio;

    private string filePath = Application.dataPath + "//_test//" + "_test.txt";
    private StreamWriter sw;
    void Start()
    {
        textMeshPro = promptBoxText_G.GetComponent<TMP_Text>();
        myaudio = GetComponent<AudioSource>();
        if (!File.Exists(filePath))
        {
            sw = File.CreateText(filePath);//创建一个用于写入 UTF-8 编码的文本  
            //Debug.Log("文件创建成功！");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) tarPosition = anchor.GetChild(0).transform;
        if (Input.GetKeyDown(KeyCode.Alpha2)) tarPosition = anchor.GetChild(1).transform;
        if (Input.GetKeyDown(KeyCode.Alpha3)) tarPosition = anchor.GetChild(2).transform;
        if (Input.GetKeyDown(KeyCode.Alpha4)) tarPosition = anchor.GetChild(3).transform;
        if (Input.GetKeyDown(KeyCode.Alpha5)) tarPosition = anchor.GetChild(4).transform;
        if (Input.GetKeyDown(KeyCode.Alpha6)) tarPosition = anchor.GetChild(5).transform;

        if (testModeFlag == true)
        {
            promptBoxText = "Please Pointing the " + tarPosition.name;
            textMeshPro.text = promptBoxText;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                WriteData();
                myaudio.Play();
                if (tarPosiNum < 5)
                {
                    tarPosiNum++;
                }
                else
                {
                    playerPosi++;                //结束本轮测试，传送至下个点，开始下一轮测试
                    if (playerPosi < 5)
                    {
                        tarPosiNum = playerPosi + 1;
                        GameObject.Find("Teleport").GetComponent<Teleport>().Tele(playerPosi);
                    }
                    else
                    {
                        playerPosi = 0;
                        tarPosiNum = 1;
                        GameObject.Find("Teleport").GetComponent<Teleport>().Tele(0);
                        GameObject.Find("PromptBox").SetActive(false);
                        testModeFlag = false;
                    }
                }
                tarPosition = anchor.GetChild(tarPosiNum).transform;

            }
        }

    }

    private float CalculateAngle()
    {
        Vector3 targetDir = Vector3.ProjectOnPlane(tarPosition.position - mycamera.transform.position, Vector3.up); // 目标坐标与当前坐标差的向量
        Vector3 faceDir = Vector3.ProjectOnPlane(mycamera.transform.forward, Vector3.up);
        return Vector3.Angle(faceDir, targetDir); // 返回当前坐标与目标坐标的角度
    }
    public void WriteFileByLine(string str_info)
    {
        sw = File.AppendText(filePath);//打开现有 UTF-8 编码文本文件以进行读取  
        sw.WriteLine(str_info);//以行为单位写入字符串  
        sw.Dispose();//文件流释放  
        sw.Close();
    }

    public void ChangeMode(bool flag)
    {
        testModeFlag = flag;
    }

    private void WriteData()
    {
        deltaTime = Time.time - Teleport.startTestTime;
        msg = "Anchor " + tarPosition.name + ":" + CalculateAngle().ToString()
            + " Latency: " + deltaTime;
        Debug.Log(msg);
        WriteFileByLine(msg);
        Teleport.startTestTime = Time.time;
    }

    public void TestCounter()
    {
        testNum++;
        string ms = "No." + testNum + " Test:";
        WriteFileByLine(ms);
    }
}


