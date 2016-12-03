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

        RanomRoom();

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
            m_LCubes.Add(Instantiate(m_Cubes, m_CubePos, Quaternion.identity));
            for (int j = 0; j < randZ; j++)
            {
                m_CubePos.z = j;
                m_LCubes.Add(Instantiate(m_Cubes, m_CubePos, Quaternion.identity));
                //Same with z and j
            }
        }

        int m;
        for (int l = 0; l < m_LCubes.Count; l++)
        {
            m = 0;
            for (; m < m_LCubes.Count; m++)
            {
                if (l != m)//Check aslong as its not on the same list position              
                {
                    //Check if there is another object in the same list and removes it if they are the same.
                    //Removes the GameObject cube and the position in the list
                    if (m_LCubes[l].transform.position == m_LCubes[m].transform.position)
                    {
                        print("Equal position to another obejct!");
                        Destroy(m_LCubes[m]);
                        m_LCubes.RemoveAt(m);
                       
                    }
                }
                
            }                
        }
        // Sets all the GameObjects from the list to a empty GameObject as parent
        foreach (GameObject a in m_LCubes)
        {
            a.transform.parent = parentRoom.transform;

        }

    }
    void RanomRoom()
    {
        //Random the number of rooms then creats a clone of an emptyGameObject
        int randNRRooms = Random.Range(5, 10);
        for (int i = 0; i < randNRRooms; i++)
        {
            GameObject nu = (GameObject)Instantiate(m_Rooms);
            m_LRooms.Add(nu);
            CreateRandomRoom(nu);
        }
    }


}
