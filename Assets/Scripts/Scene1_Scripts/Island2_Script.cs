using UnityEngine;

public class Island2_Script : MonoBehaviour
{
    public GameObject player;
    
    public GameObject[] specialPositions;
    public GameObject indicator2;
    //Enemies
    public GameObject[] enemies;
    public float enemySpeed = 0f;
    private float direction = 1f;
    private float direction2 = 1f;
    private float direction3 = -1f;
    private float direction4 = -1f;
    private float direction5 = 1f;

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
            //Enemy 1
            enemies[0].transform.position += new Vector3(enemySpeed, 0f, 0f) * direction * Time.deltaTime;
            if (enemies[0].transform.position.x > 13f)
            {
                direction = -1f;
            }
            else if (enemies[0].transform.position.x < 3f)
            {
                direction = 1f;
            }
            //Enemy 2
            enemies[1].transform.position += new Vector3(enemySpeed, 0f, 0f)*direction2*Time.deltaTime;
            if (enemies[1].transform.position.x > 13f)
            {
                direction2 = -1f;
            }
            else if (enemies[1].transform.position.x < 3f)
            {
                direction2 = 1f;
            }
            //Enemy 3
            if (enemies[2].transform.position.z >= 25f && enemies[2].transform.position.x > 17f)
            {
                enemies[2].transform.position += new Vector3(-enemySpeed,0f,0f)*Time.deltaTime;
            } 
            else if (enemies[2].transform.position.x <= 17f && enemies[2].transform.position.z > 20f)
            {
                enemies[2].transform.position += new Vector3(0f,0f,-enemySpeed)*Time.deltaTime;
            }
            else if (enemies[2].transform.position.z <= 20f && enemies[2].transform.position.x < 23f)
            {
                enemies[2].transform.position += new Vector3(enemySpeed,0f,0f)*Time.deltaTime;
            }
            else if (enemies[2].transform.position.x >= 23f && enemies[2].transform.position.z < 25f)
            {
                enemies[2].transform.position += new Vector3(0f,0f,enemySpeed)*Time.deltaTime;
            }
            //Enemy 4
            if (enemies[3].transform.position.x <= 23f && enemies[3].transform.position.z < 14f)
            {
                enemies[3].transform.position += new Vector3(0f,0f,enemySpeed)*Time.deltaTime;
            } 
            else if (enemies[3].transform.position.z >= 14f && enemies[3].transform.position.x < 29f)
            {
                enemies[3].transform.position += new Vector3(enemySpeed,0f,0f)*Time.deltaTime;
            }
            else if (enemies[3].transform.position.x >= 29f && enemies[3].transform.position.z > 9f)
            {
                enemies[3].transform.position += new Vector3(0f,0f,-enemySpeed)*Time.deltaTime;
            }
            else if (enemies[3].transform.position.z <= 9f && enemies[3].transform.position.x > 23f)
            {
                enemies[3].transform.position += new Vector3(-enemySpeed,0f,0f)*Time.deltaTime;
            }
            //Enemy 5
            enemies[4].transform.position += new Vector3(0f, 0f, enemySpeed)*direction3*Time.deltaTime;
            if (enemies[4].transform.position.z > 15f)
            {
                direction3 = -1f;
            }
            else if (enemies[4].transform.position.z < 5f)
            {
                direction3 = 1f;
            }

            //Enemy 6
            enemies[5].transform.position += new Vector3(0f, 0f, enemySpeed)*direction4*Time.deltaTime;
            if (enemies[5].transform.position.z < 3f)
            {
                direction4 = 1f;
            }
            else if (enemies[5].transform.position.z > 15f)
            {
                direction4 = -1f;
            }
            //Enemy 7
            enemies[6].transform.position += new Vector3(0f, 0f, enemySpeed)*direction5*Time.deltaTime;
            if (enemies[6].transform.position.z > 13f)
            {
                direction5 = -1f;
            }
            else if (enemies[6].transform.position.z < 5f)
            {
                direction5 = 1f;
            }
        }
        
    }

}
