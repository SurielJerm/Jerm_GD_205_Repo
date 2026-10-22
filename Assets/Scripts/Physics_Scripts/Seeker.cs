using UnityEngine;

public class Seeker : MonoBehaviour
{
    public Transform target;
    public float speed = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // FixedUpdate is called once per standardized interval
    void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter(Collider seekerSight)
    {
        if (seekerSight.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().WakeUp();
            Vector3 targetOffset = target.position - transform.position;
            Vector3 targetDirection = Vector3.Normalize(targetOffset);

            GetComponent<Rigidbody>().AddForce(targetDirection * speed);
        }
    }
    private void OnTriggerExit(Collider seekerSight)
    {
        if (seekerSight.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().Sleep();
        }
    }
    private void OnCollisionEnter(Collision seekerCol)
    {
        Destroy(seekerCol.gameObject);
    }
}
