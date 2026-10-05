using UnityEngine;

public class Island2_Script : MonoBehaviour
{
    public GameObject player;
    
    public GameObject[] specialPositions;
    public GameObject indicator2;
    //Enemies
    public GameObject Enmy1;
    public GameObject Enmy2;
    public GameObject Enmy3;
    public GameObject Enmy4;
    public GameObject Enmy5;
    public GameObject Enmy6;
    public GameObject Enmy7;

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
            if (specialPositions[i].transform.GetComponent<Renderer>().material.color == Color.green)
            {
                player.transform.position = indicator2.transform.position + new Vector3(0f,1f,0f);
                indicator2.transform.GetComponent<Renderer>().material.color = Color.green;
            }
        }

        //Enemy Stuff

        
    }
}
