using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] Anchor; 
    public float speed = 10.0f;
    public static float startTestTime = 0f;

    private CharacterController playercontroller;

    public Transform player;
    void Start()
    {
        player.position.Set(0, player.position.y, 0);
        playercontroller = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) TransPort(Anchor[0]);
        if (Input.GetKeyDown(KeyCode.F2)) TransPort(Anchor[1]);
        if (Input.GetKeyDown(KeyCode.F3)) TransPort(Anchor[2]);
        if (Input.GetKeyDown(KeyCode.F4)) TransPort(Anchor[3]);
        if (Input.GetKeyDown(KeyCode.F5)) TransPort(Anchor[4]);
        if (Input.GetKeyDown(KeyCode.F6)) TransPort(Anchor[5]);
    }

    private void TransPort(Transform anchor)
    {
        Vector3 newposi = anchor.position;
        playercontroller.enabled = false;
        player.transform.position = newposi;
        playercontroller.enabled = true;
        startTestTime = Time.time;
    }

    public void Tele(int n)
    {
        TransPort(Anchor[n]);
        Debug.Log("´«ËÍ³É¹¦");
    }
}
