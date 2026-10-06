using UnityEngine;

public class Island2_Script : MonoBehaviour
{
    public GameObject player;
    
    public GameObject[] specialPositions;
    public GameObject indicator2;
    //Enemies
    public GameObject[] enemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Special Positions
        for (int i = 0; i < specialPositions.Length; i++)
        {
            if (player.transform.position == specialPositions[i].transform.position + new Vector3(0f,1f,0f))
            {
                specialPositions[i].transform.GetComponent<Renderer>().material.color = Color.green;
            }
            
            //Win
            if (specialPositions[0].transform.GetComponent<Renderer>().material.color == Color.green && specialPositions[1].transform.GetComponent<Renderer>().material.color == Color.green && specialPositions[2].transform.GetComponent<Renderer>().material.color == Color.green && player.transform.position == specialPositions[2].transform.position + new Vector3(0f,1f,0f))
            {
                player.transform.position = indicator2.transform.position + new Vector3(0f,1f,0f);
                indicator2.transform.GetComponent<Renderer>().material.color = Color.green;
            }
        }

        //Enemy Stuff
        for (int i = 0; i < enemies.Length; i++)
        {
            if (player.transform.position == enemies[i].transform.position)
            {
                player.transform.position = indicator2.transform.position + new Vector3(3f,1f,0f);
            }
            //Enemy 1
            if (enemies[0].transform.position.x <= 13f)
            {
                enemies[0].transform.position += new Vector3(1f,0f,0f);
            }
            else if(enemies[0].transform.position.x >= 3f)
            {
                enemies[0].transform.position += new Vector3(-1f,0f,0f);
            }


        }
        
    }
}
