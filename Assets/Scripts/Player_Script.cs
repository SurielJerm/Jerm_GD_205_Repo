using UnityEngine;
using UnityEngine.InputSystem;
public class Player_Script : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    public Rigidbody playerBody;
    public float moveSpeed = 0f;
    public float jumpForce = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //playerBody.isKinematic = true;

        //Player Movement
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        playerBody.MovePosition(transform.position + move * moveSpeed * Time.fixedDeltaTime);

        //Player Jump
        if (jumpAction.WasPressedThisFrame())
        {
            //playerBody.isKinematic = false;
            playerBody.AddRelativeForce(Vector3.up * jumpForce);
        }
    }
}
