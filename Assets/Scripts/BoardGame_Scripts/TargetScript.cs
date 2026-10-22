using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider targetCol)
    {
        if (targetCol.gameObject.CompareTag("Player"))
        {
            transform.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
