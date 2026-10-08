using UnityEngine;

public class Island1_Script : MonoBehaviour
{
    public GameObject player;
    public GameObject indicator1;
    
    public Transform ascendPoint1;
    public Transform ascendPoint2;
    public float ascendSpeed = 0f;
    
    public Transform descendPoint1;
    public Transform descendPoint2;
    public float descendSpeed = 0f;
    
    public Transform slidePoint;
    public float slideSpeed = 0f;

    public GameObject[] targets;
    
    public GameObject ResetPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Elevator
            //Up
        if (player.transform.position.x == ascendPoint1.position.x && player.transform.position.z == ascendPoint1.position.z && player.transform.position.y <= ascendPoint2.position.y + 1f)
        {
            player.transform.position += new Vector3(0f,1f, 0f)*ascendSpeed*Time.deltaTime;
        }
        if (player.transform.position.y > ascendPoint2.position.y + 1f)
        {
            player.transform.position = ascendPoint2.position + new Vector3(0f, 1f, 0f);
        }
            //Down
        if (player.transform.position.x == descendPoint1.position.x && player.transform.position.z == descendPoint1.position.z && player.transform.position.y >= descendPoint2.position.y + 1f)
        {
            player.transform.position += new Vector3(0f,-1f, 0f)*descendSpeed*Time.deltaTime;
        }
        if (player.transform.position.y < descendPoint2.position.y + 1f)
        {
            player.transform.position = descendPoint2.position + new Vector3(0f,1f,0f);
        }
        
        //On-rails Section
        if (player.transform.position.x <= slidePoint.position.x && player.transform.position.y >= slidePoint.position.y + 1f && player.transform.position.z >= slidePoint.position.z)
        {
            player.transform.position += new Vector3(0f,0f,1f)*slideSpeed*Time.deltaTime;
        }
        else if (player.transform.position.x >= slidePoint.position.x && player.transform.position.y >= slidePoint.position.y + 1f && player.transform.position.z >= slidePoint.position.z)
        {
            player.transform.position = player.transform.position + new Vector3(0f,0f,1f)*slideSpeed*Time.deltaTime;
        }
        
            //Targets
        for (int i = 0; i < targets.Length; i++)
        {
            
        }
        
        //Reset/Win
        if (player.transform.position == ResetPoint.transform.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = slidePoint.position + new Vector3(0f,1f,-1f);
        }

    }
}
