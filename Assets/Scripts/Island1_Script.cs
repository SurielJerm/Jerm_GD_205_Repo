using UnityEngine;

public class Island1_Script : MonoBehaviour
{
    public GameObject player;

    public GameObject indicator1;
    public Transform ascendPoint1;
    public Transform ascendPoint2;
    public float ascendSpeed = 0.1f;
    public Transform descendPoint1;
    public Transform descendPoint2;
    public float descendSpeed = 0.1f;
    public Transform slidePoint;
    public float slideSpeed = 0.2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Up
        if (player.transform.position.x == ascendPoint1.position.x && player.transform.position.z == ascendPoint1.position.z && player.transform.position.y <= ascendPoint2.position.y + 1f)
        {
            player.transform.position = player.transform.position + new Vector3(0f, ascendSpeed, 0f);
        }
        if (player.transform.position == ascendPoint2.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = ascendPoint2.position + new Vector3(0f, 1f, 0f);
        }
        //Down
        if (player.transform.position.x == descendPoint1.position.x && player.transform.position.z == descendPoint1.position.z && player.transform.position.y >= descendPoint2.position.y + 1f)
        {
            player.transform.position = player.transform.position + new Vector3(0f, -descendSpeed, 0f);
        }
        if (player.transform.position == descendPoint2.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = descendPoint2.position + new Vector3(0f,1f,0f);
        }
        //Slide
        if (player.transform.position.x <= slidePoint.position.x && player.transform.position.y >= slidePoint.position.y + 1f && player.transform.position.z >= slidePoint.position.z)
        {
            player.transform.position = player.transform.position + new Vector3(0f,0f,slideSpeed);
        }
        else if (player.transform.position.x >= slidePoint.position.x && player.transform.position.y >= slidePoint.position.y + 1f && player.transform.position.z >= slidePoint.position.z)
        {
            player.transform.position = player.transform.position + new Vector3(0f,0f,slideSpeed);
        }
        //Reset
        if (player.transform.position.z >= 136f)
        {
            player.transform.position = slidePoint.position + new Vector3(0f,1f,-1f);
        }
            //Special Positions

    }
}
