using UnityEngine;
using UnityEngine.InputSystem;
public class Player_Script : MonoBehaviour
{
    private InputAction moveAction;
    public float moveSpeed = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player Movement
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        GetComponent<Rigidbody>().MovePosition(transform.position + move * moveSpeed * Time.fixedDeltaTime);
    }
}
