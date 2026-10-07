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
            enemies[i].GetComponent<Collider>().isTrigger = true;

            if (player.transform.position == enemies[i].transform.position + new Vector3(0f,1f,0f))
            {
                player.transform.position = indicator2.transform.position + new Vector3(3f,1f,0f);
            }
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
            if (enemies[2].transform.position == new Vector3(23f,0f,25f))
            {
                enemies[2].transform.position += new Vector3(-enemySpeed,0f,0f)*Time.deltaTime;
            } 
            else if (enemies[2].transform.position == new Vector3(17f,0f,25f))
            {
                enemies[2].transform.position += new Vector3(0f,0f,-enemySpeed)*Time.deltaTime;
            }
            else if (enemies[2].transform.position == new Vector3(17f,0f,20f))
            {
                enemies[2].transform.position += new Vector3(enemySpeed,0f,0f)*Time.deltaTime;
            }
            else if (enemies[2].transform.position == new Vector3(23f,0f,20f))
            {
                enemies[2].transform.position += new Vector3(enemySpeed,0f,0f)*Time.deltaTime;
            }

        }
        
    }

    private void OnTriggerEnter(Collider enemieCol)
    {
        if (enemieCol.gameObject.CompareTag("Player"))
        {
        Debug.Log("Triggered by: " + enemieCol.gameObject.name);
        }
    }
}
