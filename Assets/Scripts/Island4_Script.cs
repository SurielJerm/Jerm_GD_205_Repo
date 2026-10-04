using UnityEngine;

public class Island4_Script : MonoBehaviour
{
    public GameObject player;
    
    public Transform spawnPoint;
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
