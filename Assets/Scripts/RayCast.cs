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
    public float lift = 0f;
    public float camSpeed = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        cursorAction = InputSystem.actions.FindAction("Point");
        clickAction = InputSystem.actions.FindAction("Click");
        middleMouse = InputSystem.actions.FindAction("MiddleClick");
        
        transform.Rotate(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        //Player Cam
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        Vector3 look = new Vector3(-lookInput.y, lookInput.x, 0f);
        transform.Rotate(look * camSpeed *Time.deltaTime);
        //transform.localRotation = Quaternion.Euler(look);

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

        if (Physics.Raycast(laserRay, out laserHit))
        {
            Debug.Log("Hit:" + laserHit.collider.gameObject.name);
            laserHit.rigidbody.AddExplosionForce(force, laserHit.point, radius, lift);
        }
        else if (laserHit.collider.gameObject.CompareTag("Player"))
        {
            laserHit.rigidbody.AddExplosionForce(0f, laserHit.point, 0f);
        }
    }
}
