using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    private float mouseX, mouseY;
    public float mouseSens;
    private GameObject player;

    private float xRotation;
    private Vector3 yRotation;
    private Vector3 velocity = Vector3.zero;

    private Scrollbar scrollbar;
    public GameObject mouseSensOnBar;


    void Start()
    {
        player = transform.parent.GameObject();
        scrollbar = mouseSensOnBar.GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseSens = scrollbar.value * 1000;
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        //yRotation = xRotation * Vector3.right;
        //yRotation = Vector3.SmoothDamp(transform.rotation.euler, yRotation, ref velocity, Time.deltaTime);

        player.transform.Rotate(0, mouseX, 0);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
