using UnityEngine;
using UnityEngine.InputSystem;

public class TestMovement : MonoBehaviour
{
    InputAction moveAction;
    int ricksAge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ricksAge = 55;
        Debug.Log("This is a message from Start");
        Debug.Log("Rick's age is:" + ricksAge);
        moveAction = InputSystem.actions.FindAction("move");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("This is a message from update");
        Vector2 rawMove = moveAction.ReadValue<Vector2>();
        Debug.Log(moveAction.ReadValue<Vector2>());

    if (moveAction.WasPressedThisFrame())
        {
            transform.position += new Vector3(rawMove.x, 0f,rawMove.y);
        }
    }
}
