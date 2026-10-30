using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCast : MonoBehaviour
{
    //Input Actions
    InputAction lookAction;
    InputAction cursorAction;
    InputAction clickAction;
    InputAction middleMouse;
    
    //Explosion Stuff
    public float force = 0f;
    public float radius = 0f;
    public float lift;

    //Camera Stuff
    public float camSpeed = 0f;
    float xRotation; // Varibales are private by default so you don't need to type out "private"
    float yRotation;
    [SerializeField] float clamp = 30f; // SerializeField makes things visible in Inspector, but keeps them private
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        cursorAction = InputSystem.actions.FindAction("Point");
        clickAction = InputSystem.actions.FindAction("Click");
        middleMouse = InputSystem.actions.FindAction("MiddleClick");
        lift = force/2;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Player Cam
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        float x = lookInput.x * Time.deltaTime * camSpeed;
        float y = lookInput.y * Time.deltaTime * camSpeed;
        //Vector3 look = new Vector3(-lookInput.y, lookInput.x, 0f);
        
        //transform.Rotate(look * camSpeed *Time.deltaTime);
        yRotation += x;
        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -clamp, clamp);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

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
        //Ray laserRay = Camera.main.ScreenPointToRay(cursorAction.ReadValue<Vector2>());
        Ray laserRay = Camera.main.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0f));
        RaycastHit laserHit = new RaycastHit();

        //Hitting Enemies/Missle + Ignore Player Rigidbody
        if (Physics.Raycast(laserRay, out laserHit))
        {
            Debug.Log("Hit:" + laserHit.collider.gameObject.name);
            laserHit.rigidbody.AddExplosionForce(force, laserHit.point, radius, lift);
        }
        else if (laserHit.collider.gameObject.CompareTag("Player"))
        {
            laserHit.rigidbody.AddExplosionForce(0f, laserHit.point, 0f, 0f);
        }
        
    }
}
