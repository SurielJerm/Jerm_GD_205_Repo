using UnityEngine;
using UnityEngine.InputSystem;

public class RayCast : MonoBehaviour
{
    private InputAction cursorAction;
    private InputAction clickAction;
    public float force = 0f;
    public float radius = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cursorAction = InputSystem.actions.FindAction("Point");
        clickAction = InputSystem.actions.FindAction("Click");
    }

    // Update is called once per frame
    void Update()
    {
        Ray laserRay = Camera.main.ScreenPointToRay(cursorAction.ReadValue<Vector2>());
        RaycastHit laserHit = new RaycastHit();

        if (clickAction.IsPressed() && Physics.Raycast(laserRay, out laserHit))
        {
            Debug.Log("Hit:" + laserHit.collider.gameObject.name);
            laserHit.rigidbody.AddExplosionForce(force, -laserHit.point, radius);
        }



    }
}
