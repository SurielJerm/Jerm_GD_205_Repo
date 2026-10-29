using UnityEngine;

public class EnemyB_Script : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public Transform playerPos;
    public GameObject tower1;
    public GameObject tower2;
    public float speed;
    public float force = 0f;
    public float radius = 0f;
    public float lift = 0f;
    private float choice;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //A random selection is made to determine the enemy's target
        choice = Random.Range(1,2);

        lift = force/2;
        player = GameObject.FindGameObjectWithTag("Player");
        tower1 = GameObject.FindGameObjectWithTag("Tower1");
        tower2 = GameObject.FindGameObjectWithTag("Tower2");
        
    }

    void FixedUpdate()
    {
        if (choice == 1)
        {
            target = tower1.transform;
        }
        else if (choice == 2)
        {
            target = tower2.transform;
        }
        //Enemy Movement
        Vector3 targetOffset = target.position - transform.position;
        Vector3 targetDirection = Vector3.Normalize(targetOffset);
        GetComponent<Rigidbody>().AddRelativeForce(targetDirection * speed);
    }

    private void OnTriggerEnter(Collider seekerSight)
    {
        if (player)
        {
            target = player.transform;
        }
    }

    private void OnTriggerExit(Collider enmySight)
    {
        if (player)
        {
            choice = Random.Range(1,2); //When the player leaves enmySight random target selection initiates again
        }
    }

    private void OnCollisionEnter(Collision enmyCol)
    {
        if (player)
        {
            enmyCol.rigidbody.AddExplosionForce(force, gameObject.transform.position, radius, lift);
        }
    }
}
