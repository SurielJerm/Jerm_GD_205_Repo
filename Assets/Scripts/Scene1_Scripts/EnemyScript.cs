using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject player;
    private GameObject indicator2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        indicator2 = GameObject.FindWithTag("Indicator2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Triggered by: " + collision.gameObject.name);
            player.transform.position = indicator2.transform.position + new Vector3(3f,1f,0f);
        }
    }
}
