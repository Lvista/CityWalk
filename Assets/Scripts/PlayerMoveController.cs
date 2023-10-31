using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController cc;
    public float moveSpeed;
    public float jumpSpeed;

    private float horizontalMove, verticalMove;
    private Vector3 dir;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;
    public float gravity;
    private Vector3 velocity;
    public bool isGround;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);

        //手动编写一个重力模块
        velocity.y -= gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);   //自由落体方式控制下落
    }
}
