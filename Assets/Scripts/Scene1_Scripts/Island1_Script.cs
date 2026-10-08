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
    public float targetSpeed = 0f;
    private float direction1 = -1f;
    private float direction2 = -1f;
    private float direction3 = 1f;
    
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
                //Target 1
            targets[0].transform.position += new Vector3(direction1,0f,0f)*targetSpeed*Time.deltaTime;
            if (targets[0].transform.position.x < -6f)
            {
                direction1 = 1f;
            }
            else if (targets[0].transform.position.x > -2f)
            {
                direction1 = -1f;
            }
                //Target 2
            targets[1].transform.position += new Vector3(direction2,0f,0f)*targetSpeed*Time.deltaTime;
            if (targets[1].transform.position.x < -6f)
            {
                direction2 = 1f;
            }
            else if (targets[1].transform.position.x > -2f)
            {
                direction2 = -1f;
            }
                //Target 3
            targets[2].transform.position += new Vector3(direction3,0f,0f)*targetSpeed*Time.deltaTime;
            if (targets[2].transform.position.x < -6f)
            {
                direction3 = 1f;
            }
            else if (targets[2].transform.position.x > -2f)
            {
                direction3 = -1f;
            }
        }
        
        //Reset/Win
        if (player.transform.position.z > 137f && (targets[0].transform.GetComponent<Renderer>().material.color != Color.green || targets[1].transform.GetComponent<Renderer>().material.color != Color.green || targets[2].transform.GetComponent<Renderer>().material.color != Color.green))
        {
            player.transform.position = slidePoint.position + new Vector3(0f,1f,-1f);
        }
        else if (player.transform.position.z > 137f && targets[0].transform.GetComponent<Renderer>().material.color == Color.green && targets[1].transform.GetComponent<Renderer>().material.color == Color.green && targets[2].transform.GetComponent<Renderer>().material.color == Color.green)
        {
            player.transform.position = indicator1.transform.position + new Vector3(0f,1f,0f);
            indicator1.transform.GetComponent<Renderer>().material.color = Color.green;
        }

    }
}
