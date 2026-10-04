using UnityEngine;

public class Island1_Script : MonoBehaviour
{
    public GameObject player;

    public Transform acsendPoint1;
    public Transform acsendPoint2;
    public Transform decendPoint1;
    public Transform decendPoint2;
    public Transform slidePoint;
    public GameObject specialPos1;
    public GameObject specialPos2;
    public GameObject specialPos3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            //Up
        if (player.transform.position.x == acsendPoint1.position.x && player.transform.position.z == acsendPoint1.position.z && player.transform.position.y <= acsendPoint2.position.y + 1f)
        {
            player.transform.position = player.transform.position + new Vector3(0f, 0.1f, 0f);
        }
        if (player.transform.position == acsendPoint2.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = acsendPoint2.position + new Vector3(0f, 1f, 0f);
        }
            //Down
        if (player.transform.position.x == decendPoint1.position.x && player.transform.position.z == decendPoint1.position.z && player.transform.position.y >= decendPoint2.position.y + 1.1f)
        {
            player.transform.position = player.transform.position + new Vector3(0f, -0.1f, 0f);
        }
        if (player.transform.position == decendPoint2.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = decendPoint2.position + new Vector3(0f,1f,0f);
        }
            //Slide
        if (player.transform.position.x <= slidePoint.position.x && player.transform.position.y >= slidePoint.position.y + 1f && player.transform.position.z >= slidePoint.position.z)
        {
            player.transform.position = player.transform.position + new Vector3(0f,0f,0.1f);
        }
        else if (player.transform.position.x >= slidePoint.position.x && player.transform.position.y >= slidePoint.position.y + 1f && player.transform.position.z >= slidePoint.position.z)
        {
            player.transform.position = player.transform.position + new Vector3(0f,0f,0.1f);
        }
            //Reset
        if (player.transform.position.z >= 136f)
        {
            player.transform.position = slidePoint.position + new Vector3(0f,1f,-1f);
        }
            //Special Positions
        if (player.transform.position == specialPos1.transform.position + new Vector3(0f,1f,0f))
        {
            specialPos1.transform.GetComponent<Renderer>().material.color = Color.green;
        }
        if (player.transform.position == specialPos2.transform.position + new Vector3(0f,1f,0f))
        {
            specialPos2.transform.GetComponent<Renderer>().material.color = Color.green;
        }
        if (player.transform.position == specialPos3.transform.position + new Vector3(0f,1f,0f))
        {
            specialPos3.transform.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
