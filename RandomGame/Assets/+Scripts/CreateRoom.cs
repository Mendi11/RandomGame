﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoom : MonoBehaviour
{

    public List<GameObject> m_LCubes;
    List<GameObject> m_LRooms = new List<GameObject>();
    public LayerMask m_unwalkableMask;
    int x = 0;
    bool coli = true;
    public GameObject Player;
    List<bool> m_Collision = new List<bool>();
    [SerializeField]
    GameObject m_Hall_Cubes;
    [SerializeField]
    GameObject m_Cubes;
    private Vector3 m_CubePos;
    bool done;
    bool start = false;

    // Use this for initialization
    void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            m_Collision.Add(false);

        }

    }

    void Start()
    {
        done = false;

        CreateRandomRoom();
     

    }
    void Update()
    {
        int col = 0;
        for (int i = 0; i < m_LCubes.Count; i++)
        {
            print(m_LCubes[i].GetComponent<CollisionScr>().CollisionRoom);
            if (m_LCubes[i].GetComponent<CollisionScr>().CollisionRoom == false && start == true)
            {
                m_Collision[i] = true;

            }
            else
            {
                m_Collision[i] = false;
            }
          
        }
        for (int i = 0; i < m_Collision.Count; i++)
        {
            if (m_Collision[i] == true)
            {
                col++;

            }
            else
            {
                col--;
            }
            print(col);
        }
        
        if (col >= 5 && done == false)
        {
            ConnectRooms();

            done = true;
        }
        start = true;

    }

    // Update is called once per frame

    void CreateRandomRoom()
    {

        // Create list for a room and randoms for how many cubes for x and z pos
        m_LCubes = new List<GameObject>();
        int planeRand = Random.Range(15, 30);
         
        for (int i = 0; i < 5; i++)
        {
            int randX = Random.Range(10, 20);
            int randZ = Random.Range(10, 20);
            m_CubePos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            m_LCubes.Add(Instantiate(m_Cubes, m_CubePos, Quaternion.identity)); // Create a new Cube and adds it to the list.
            Vector3 scale = new Vector3(randX, 2, randZ);
            m_LCubes[i].transform.localScale = scale;
            m_LCubes[i].transform.name = ("Hej " + i);
        }

    }
    void ConnectRooms()
    {
        
        GameObject a, b, c = null;
        float abDist, acDist = 0, bcDist = 0;
        bool skip;

        for (int i = 0; i < m_LCubes.Count; i++)
        {
            a = m_LCubes[i];
            for (int j = i + 1; j < m_LCubes.Count; j++)
            {
                skip = false;
                b = m_LCubes[j];
                abDist = Mathf.Pow(a.transform.position.x - b.transform.position.x, 2) + Mathf.Pow(a.transform.position.z - b.transform.position.z, 2);
                for (int k = 0; k < m_LCubes.Count; k++)
                {
                    if (k == i || k == j)
                        continue;
                    c = m_LCubes[k];
                    acDist = Mathf.Pow(a.transform.position.x - c.transform.position.x, 2) + Mathf.Pow(a.transform.position.z - c.transform.position.z, 2);
                    bcDist = Mathf.Pow(b.transform.position.x - c.transform.position.x, 2) + Mathf.Pow(b.transform.position.z - c.transform.position.z, 2);

                    if (acDist < abDist && bcDist < abDist)
                    { 
                        skip = true;
                    }
                    if (skip)
                        break;

                }
                if (!skip)
                {
                    float rightSide = a.transform.localScale.x / 2;
                    if (leftOrRight(a,b))
                    {
                        float distX = a.transform.position.x - b.transform.position.x;
                        GameObject cube = Instantiate(m_Hall_Cubes, a.transform.position, Quaternion.identity);                       
                        cube.transform.localScale = new Vector3(Mathf.Abs(distX), 0.1f, 2);
                        cube.transform.position += new Vector3((-distX / 2) - 1, 0.95f, 0);

                      
                    }
                    else if (!leftOrRight(a, b))
                    {
                        float distX = b.transform.position.x - a.transform.position.x;
                        GameObject cube = Instantiate(m_Hall_Cubes, a.transform.position, Quaternion.identity);
                        cube.transform.localScale = new Vector3(Mathf.Abs(distX), 0.1f, 2);
                        cube.transform.position += new Vector3(Mathf.Abs(distX / 2) + 1 , 0.95f,0);
                        
                    }
                    if (topOrBottom(a, b))
                    {
                        float distZ = a.transform.position.z - b.transform.position.z;
                        GameObject cube = Instantiate(m_Hall_Cubes, b.transform.position, Quaternion.identity);
                        cube.transform.localScale = new Vector3(2, 0.1f, Mathf.Abs(distZ));
                        cube.transform.position += new Vector3(0, 0.95f, (distZ / 2) + 1);


                    }
                     else if (!topOrBottom(a, b))
                    {
                        float distZ = b.transform.position.z - a.transform.position.z;
                        GameObject cube = Instantiate(m_Hall_Cubes, b.transform.position, Quaternion.identity);
                        cube.transform.localScale = new Vector3(2, 0.1f, Mathf.Abs(distZ));
                        cube.transform.position += new Vector3(0, 0.95f, (-distZ / 2) - 1);
                    }

                }
            } 
        }
    }

    bool leftOrRight(GameObject a, GameObject b)
    {
        return a.transform.position.x > b.transform.position.x;// if a.x is bigger then b is left of a
    }
    bool topOrBottom(GameObject a, GameObject b)
    {
        return a.transform.position.z > b.transform.position.z; // if a.z is bigger then b is below a
    }
    public void Math(GameObject a, GameObject b)
    {

        float aRight = a.transform.localScale.x / 2;
        float bRight = b.transform.localScale.x / 2;
        float aLeft = -a.transform.localScale.x / 2;
        float bLeft = -b.transform.localScale.x / 2;
        float aTop = a.transform.localScale.z / 2;
        float bTop = b.transform.localScale.z / 2;
        float aBottom = -a.transform.localScale.z / 2;
        float bBottom = -b.transform.localScale.z / 2;



        float dx, dxa, dxb, dy, dya, dyb;
        dx = Mathf.Min(aRight - bLeft + 2, aLeft - bRight - 2);
        dy = Mathf.Min(aBottom - bTop + 2, aTop - bBottom - 2);


        if (Mathf.Abs(dx) < Mathf.Abs(dy))
        {
            dy = 0;
        }
        else
        {
            dx = 0;
        }


        dxa = -dx / 2;
        dxb = dx + dxa;

        dya = -dy / 2;
        dyb = dy + dya;


        //print("Colliding!");
        if (x > 20)
        {
            a.transform.position += new Vector3(dxa + 50, 0, dya + 50) * Time.deltaTime;
            b.transform.position += new Vector3(dxb, 0, dyb) * Time.deltaTime;
            x = 0;
        }
        else
        {
            a.transform.position += new Vector3(dxa, 0, dya) * Time.deltaTime;
            b.transform.position += new Vector3(dxb, 0, dyb) * Time.deltaTime;
            x++;
        }


    }

    public void Collision(GameObject a,GameObject b)
    {
        Math(a, b);
    }
    public bool CollisionBool(bool collision)
    {
        coli = collision;
        return collision;
    }

}
