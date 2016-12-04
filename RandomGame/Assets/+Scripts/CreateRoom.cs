using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoom : MonoBehaviour {

    List<GameObject> m_LCubes;
    List<GameObject> m_LRooms = new List<GameObject>();

    [SerializeField]
    GameObject m_Cubes;
    [SerializeField]
    GameObject m_Rooms;
    private Vector3 m_CubePos;
    // Use this for initialization
    void Start ()
    {
     
        RandomRoom();
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateRandomRoom(GameObject parentRoom)
    {
  
       // Create list for a room and randoms for how many cubes for x and z pos
        m_LCubes = new List<GameObject>();
        int randX = Random.Range(3, 10);
        int randZ = Random.Range(3, 10);
        m_CubePos = transform.position;
        for (int i = 0; i < randX; i++)
        {      
            m_CubePos.x = i;//x is equal to the number of i. If i is 0 position x is 0 and so on.
            for (int j = 0; j < randZ; j++)
            {
                m_CubePos.z = j;
                m_LCubes.Add(Instantiate(m_Cubes, m_CubePos, Quaternion.identity)); // Create a new Cube and adds it to the list.
                
                //Same with z and j
            }
        
        }
        // Sets all the GameObjects from the list to a empty GameObject as parent
        foreach (GameObject a in m_LCubes)
        {
            a.transform.parent = parentRoom.transform;
        }

    }
    void RandomRoom()
    {
        //Random the number of rooms then creats a clone of an emptyGameObject
        int randNRRooms = Random.Range(5, 10);
        for (int i = 0; i < 2; i++)
        {
            GameObject nu = (GameObject)Instantiate(m_Rooms);
           
            m_LRooms.Add(nu);
            CreateRandomRoom(nu);

        }
        if (Physics.CheckSphere(transform.position, 1))
        {
            print("HIT");

        }
        Separate();
    }
    
   
    void Separate()
    {
        //GameObject a = m_LRooms[0];
        //GameObject b = m_LRooms[1];

        //int dx, dxa, dxb, dy, dya, dyb;
        //bool hit = Physics.CheckSphere(a.transform.position, 1);
        //while (hit) a.transform.collider.
        //{



        //}





    }
}
