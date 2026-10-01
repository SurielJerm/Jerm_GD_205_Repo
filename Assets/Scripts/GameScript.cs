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
    public GameObject specialPos1;
    public GameObject specialPos2;
    public GameObject specialPos3;
    //Island 2
    public GameObject specialPos4;
    public GameObject specialPos5;
    public GameObject specialPos6;
    //Island 4
    public Transform teleEnter;
    public Transform teleSpot1;
    public Transform teleSpot2;
    public Transform teleSpot3;
    public Transform teleSpot4;
    public Transform teleSpot5;
    public Transform teleSpot6;
    public Transform teleSpot7;
    public Transform teleSpot8;
    public Transform teleSpot9;
    public Transform teleExit;
    public GameObject WinSpot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Island 1
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

        //Island 2
        //Player must change all cubes to green
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

        //Island 4
        //A guessing game where the player must choose between three panels, the correct one teleports them to the next platform while the others return them to spawn
        if (player.transform.position == teleEnter.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = new Vector3(-48f,1f,12f);
        }
        //Guess1
        if (player.transform.position == teleSpot2.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = new Vector3(-76f,1f,29f);
        }
        else if (player.transform.position == teleSpot1.position + new Vector3(0f,1f,0f) || player.transform.position == teleSpot3.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = teleEnter.position + new Vector3(2f,1f,0f);
        }
        //Guess2
        if (player.transform.position == teleSpot4.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = new Vector3(-48f,1f,47f);
        }
        else if (player.transform.position == teleSpot5.position + new Vector3(0f,1f,0f) || player.transform.position == teleSpot6.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = teleEnter.position + new Vector3(2f,1f,0f);
        }
        //Guess3
        if (player.transform.position == teleSpot9.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = teleExit.position +new Vector3(0f,1f,0f);
        }
        else if (player.transform.position == teleSpot7.position + new Vector3(0f,1f,0f) || player.transform.position == teleSpot8.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = teleEnter.position + new Vector3(2f,1f,0f);
        }
        //Win
        if (player.transform.position == WinSpot.transform.position + new Vector3(0f,1f,0f))
        {
            WinSpot.transform.GetComponent<Renderer>().material.color = Color.green;
            player.transform.position = spawnPoint.position + new Vector3(0f,1f,0f);
            Debug.Log("You Did It!");
        }

    }
}
