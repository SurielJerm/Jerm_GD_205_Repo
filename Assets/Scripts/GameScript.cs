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
    public Transform rightTele1;
    public Transform rightTele2;
    public Transform rightTele3;
    public Transform teleExit;
    public GameObject WinSpot;
    public Transform[] wrongGuesses;

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
        //RightGuess1
        if (player.transform.position == rightTele1.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = new Vector3(-76f,1f,29f);
        }
        //RightGuess2
        if (player.transform.position == rightTele2.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = new Vector3(-48f,1f,47f);
        }
        //RightGuess3
        if (player.transform.position == rightTele3.position + new Vector3(0f,1f,0f))
        {
            player.transform.position = teleExit.position +new Vector3(0f,1f,0f);
        }
        //Win
        if (player.transform.position == WinSpot.transform.position + new Vector3(0f,1f,0f))
        {
            WinSpot.transform.GetComponent<Renderer>().material.color = Color.green;
            player.transform.position = spawnPoint.position + new Vector3(0f,1f,0f);
            Debug.Log("You Did It!");
        }
        for (int i = 0; i < wrongGuesses.Length; i++)
        {
            if (player.transform.position == wrongGuesses[i].position + new Vector3(0f,1f,0f))
            {
                player.transform.position = teleEnter.position + new Vector3(1f,1f,0f);
            }
        }

    }
}
