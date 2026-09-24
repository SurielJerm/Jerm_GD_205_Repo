using UnityEngine;
using UnityEngine.InputSystem; //Adds on the new Unity input system

public class TestMovement : MonoBehaviour //Name of & kind of file
//After creating a new script, make sure it's attached to a game object so it can actually function
{
    //Variable's can be written anywhere, but if you're going to continuously refer to them it's best to at the top before Start
    InputAction moveAction; //InputAction is the class we call & "moveAction" is the name of our object
    public Camera playerCamera; //Refers to the camera
    public GameObject panel1;
    private float maxCameraHeight = 25f;
    private Vector3 Spawn = new Vector3(-11f,1.5f,30f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        moveAction = InputSystem.actions.FindAction("move");
    }

    // Update is called once per frame
    void Update()
    {
        //Player grid based movement
        Vector2 rawMove = moveAction.ReadValue<Vector2>();
        //Debug.Log(rawMove); //Shows input value in console

    if (moveAction.WasPressedThisFrame())
        {
            transform.position += new Vector3(rawMove.x, 0f,rawMove.y);
        }

        Debug.Log(transform.position); //Shows player position in console

    //Player Position Effects
        //Color Change
        if (transform.position == new Vector3(32f,1.5f,6f))
        {
            panel1.GetComponent<Renderer>().material.color = Color.green;
        }

        //Ascension
        if (transform.position == new Vector3(-3f,1.5f,50f))
        {
            transform.position += new Vector3(0f,1f,0f);
        }

        if (transform.position.y > 1.5f)
        {
            transform.position += new Vector3(0f,0.1f,0f);
        }

        //So camera doesn't go above a certain height
        if (transform.position.y > 30f)
        {
            transform.position = Spawn;
        }

        //Teleportation
        if (transform.position == new Vector3(-39f,1.5f,37f))
        {
            transform.position = new Vector3(-51f,1.5f,61f);
        }

        if (transform.position == new Vector3(-56f,1.5f,68f))
        {
            transform.position = Spawn;
        }

    }
}
