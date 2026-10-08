using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction lookAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
    }

    // You can have both Update and FixedUpdate in the same script. Some things you want in Update and some things you want in FixedUpdate
    // Update is called once per frame
    void Update()
    {
        //Player Look
        Vector2 rawLook = lookAction.ReadValue<Vector2>();
        Vector3 lookDirection = new Vector3(rawLook.y, rawLook.x,0f); // Rotating the axis
        Debug.Log("rawLook input:" + rawLook);

        transform.Rotate(lookDirection);

    }

    // FixedUpdate is called once per standardized interval
    void FixedUpdate()
    {
        //Player Movement
        Vector2 rawMove = moveAction.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(rawMove.x, 0f, rawMove.y);
        Debug.Log("rawMove input:" + rawMove);

        GetComponent<Rigidbody>().AddRelativeForce(moveDirection*10f);
        if (rawMove == Vector2.zero)
        {
            GetComponent<Rigidbody>().Sleep();
        }
        
        
    }
}
