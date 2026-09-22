using UnityEngine;
using UnityEngine.InputSystem; //Adds on the new Unity input system

public class TestMovement : MonoBehaviour //Name of & kind of file
//After creating a new script, make sure it's attached to a game object so it can actually function
{
    //Variable's can be written anywhere, but if you're going to continuously refer to them it's best to at the top before Start
    InputAction moveAction; //InputAction is the class we call & "moveAction" is the name of our object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("this is a message from start"); //To Test Start
        
        
        moveAction = InputSystem.actions.FindAction("move");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("This is a message from update"); //To test Update

        Vector2 rawMove = moveAction.ReadValue<Vector2>();
        Debug.Log(rawMove); //Shows position in console

    if (moveAction.WasPressedThisFrame())
        {
            transform.position += new Vector3(rawMove.x, 0f,rawMove.y);
        }
    }
}
