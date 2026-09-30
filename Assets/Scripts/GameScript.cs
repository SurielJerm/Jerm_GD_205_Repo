using UnityEngine;

public class GameScript : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject player;
    //Island 1
    public Transform acsendPoint1;
    public Transform acsendPoint2;
    public Transform decendPoint1;
    public Transform decendPoint2;
    public Transform slidePoint;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player Position Effects

        //Island 1
        //Up
        if (player.transform.position + new Vector3(0f,1f,0f) == acsendPoint1.position && player.transform.position != acsendPoint2.position)
        {
            player.transform.position += new Vector3(0f,0.1f,0f);
        }
        if (player.transform.position == acsendPoint2.position)
        {
            player.transform.position = acsendPoint2.position + new Vector3(0f,1f,0f);
        }
        //Down
        if (player.transform.position + new Vector3(0f,1f,0f) == decendPoint1.position && player.transform.position != decendPoint2.position)
        {
            player.transform.position += new Vector3(0f,-0.1f,0f);
        }
        if (player.transform.position + new Vector3(0f,1f,0f) == decendPoint2.position)
        {
            player.transform.position = decendPoint2.position + new Vector3(0f,1f,0f);
        }
        //Slide
        if (player.transform.position + new Vector3(0f,1f,0f) == slidePoint.position)
        {
            player.transform.position += new Vector3(0f,0f,0.1f);
        }
        if (player.transform.position.z >= 95f)
        {
            player.transform.position = slidePoint.position + new Vector3(0f,1f,0f) + new Vector3(0f,0f,-1f);
        }

        //Island 2
        //Player must change all cubes to green
        

        //Teleportation
        //A guessing game where the player must choose between three panels, the correct one teleports them to the next platform while the others return them to spawn
        if (player.transform.position == new Vector3(-39f,1.5f,37f))
        {
            player.transform.position = new Vector3(-51f,1.5f,61f);
        }

        if (player.transform.position == new Vector3(-56f,1.5f,68f))
        {
            player.transform.position = spawnPoint.position;
        }
    }
}
