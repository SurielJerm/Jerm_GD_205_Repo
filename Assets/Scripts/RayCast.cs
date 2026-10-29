using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCast : MonoBehaviour
{
    private InputAction lookAction;
    private InputAction cursorAction;
    private InputAction clickAction;
    private InputAction middleMouse;

    public float force = 0f;
    public float radius = 0f;
    public float lift;
    public float camSpeed = 0f;
    public Vector2 turn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Point");
        cursorAction = InputSystem.actions.FindAction("Point");
        clickAction = InputSystem.actions.FindAction("Click");
        middleMouse = InputSystem.actions.FindAction("MiddleClick");
        lift = force/2;
        
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Player Cam
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        //Vector3 look = new Vector3(-lookInput.y, lookInput.x, 0f);
        
        //transform.Rotate(look * camSpeed *Time.deltaTime);
        //transform.rotation = Quaternion.Euler(look * camSpeed * Time.deltaTime);

        //Debug.Log(lookInput);
    }

    void FixedUpdate()
    {
        //Player Attack on Click
        if (clickAction.WasPressedThisFrame())
        {
            RayAttack();
        }

    }

    public void RayAttack()
    {
        Ray laserRay = Camera.main.ScreenPointToRay(cursorAction.ReadValue<Vector2>());
        RaycastHit laserHit = new RaycastHit();

        //Hitting Enemies/Missle + Ignore Player Rigidbody
        if (Physics.Raycast(laserRay, out laserHit) && laserHit.collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit:" + laserHit.collider.gameObject.name);
            laserHit.rigidbody.AddExplosionForce(force, laserHit.point, radius, lift);
        }
        else if (laserHit.collider.gameObject.CompareTag("Player"))
        {
            laserHit.rigidbody.AddExplosionForce(0f, laserHit.point, 0f, 0f);
        }

        //Hitting Targets
        if (laserHit.collider.gameObject.CompareTag("Target A"))
        {
            Debug.Log("Hit:" + laserHit.collider.gameObject.name);
            laserHit.collider.gameObject.IsDestroyed();
        }
        
    }
}
