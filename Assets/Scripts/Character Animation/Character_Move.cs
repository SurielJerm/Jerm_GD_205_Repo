using UnityEngine;
using UnityEngine.InputSystem;

public class Character_Move : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private float jumpInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        //Character Walk
        GetComponent<Animator>().SetFloat("forward",moveAction.ReadValue<Vector2>().y);
        GetComponent<Animator>().SetFloat("back",moveAction.ReadValue<Vector2>().y);
        GetComponent<Animator>().SetFloat("right",moveAction.ReadValue<Vector2>().x);
        GetComponent<Animator>().SetFloat("left",moveAction.ReadValue<Vector2>().x);

        //Character Jump
        if (jumpAction.IsPressed())
        {
            jumpInput = 1;
        }
        else
        {
            jumpInput = 0;
        }
        GetComponent<Animator>().SetFloat("jump", jumpInput);

        //Character Sprint
        

    }
}
