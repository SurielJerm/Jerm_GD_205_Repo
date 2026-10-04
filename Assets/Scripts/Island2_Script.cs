using UnityEngine;

public class Island2_Script : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject player;
    
    public GameObject specialPos4;
    public GameObject specialPos5;
    public GameObject specialPos6;
    //Enemies
    public GameObject Enmy1;
    public GameObject Enmy2;
    public GameObject Enmy3;
    public GameObject Enmy4;
    public GameObject Enmy5;
    public GameObject Enmy6;
    public GameObject Enmy7;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Special Positions
        if (player.transform.position == specialPos4.transform.position + new Vector3(0f,1f,0f))
        {
            specialPos4.transform.GetComponent<Renderer>().material.color = Color.green;
        }
        if (player.transform.position == specialPos5.transform.position + new Vector3(0f,1f,0f))
        {
            specialPos5.transform.GetComponent<Renderer>().material.color = Color.green;
        }
        if (player.transform.position == specialPos6.transform.position + new Vector3(0f,1f,0f))
        {
            specialPos6.transform.GetComponent<Renderer>().material.color = Color.green;
        }
            //Win
        if (specialPos4.transform.GetComponent<Renderer>().material.color == Color.green && specialPos5.transform.GetComponent<Renderer>().material.color == Color.green && specialPos6.transform.GetComponent<Renderer>().material.color == Color.green && player.transform.position == specialPos6.transform.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = spawnPoint.position + new Vector3(0f,1f,0f);
        }
    }
}
