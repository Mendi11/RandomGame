﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoom : MonoBehaviour
{

   public List<GameObject> m_LRooms;
    List<GameObject> m_LHalls;

    GameObject m_Room;

    int x = 0;
    
    public GameObject m_Player;
    List<bool> m_Collision;
    [SerializeField]
    GameObject m_Hall_Cubes;
    [SerializeField]
    GameObject m_Cubes;
    [SerializeField]
    GameObject m_Camera;



    private Vector3 m_CubePos;
    public bool done;
    bool start;

    GameObject m_Canvas;
    GameObject m_CameraCanvas;


    // Use this for initialization
    void Awake()
    {
        
        m_CameraCanvas = GameObject.Find("Camera");
        m_Canvas = GameObject.Find("Canvas"); 
        m_Collision = new List<bool>();
        start = false;
        done = false;
        m_Room = GameObject.FindGameObjectWithTag("ParentRoom");

    }

    void Start()
    {
        CreateRandomRoom();
        for (int i = 0; i < m_LRooms.Count; i++)
        {
            m_Collision.Add(false);
        }
    }
    void Update()
    {
        ConnectRooms();
    }

    // Update is called once per frame
    void ConnectRooms()
    {
        int col = 0;
        for (int i = 0; i < m_LRooms.Count; i++)
        {
            if (m_LRooms[i].GetComponent<CollisionScr>().CollisionRoom == false && start == true)
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
        }

        if (col >= m_Collision.Count && done == false)
        {
            ConnectRoomsAlg();
            Parrent();

            for (int i = 0; i < m_LRooms.Count; i++)
            {
                m_LRooms[i].GetComponent<BoxCollider>().isTrigger = false;

            }
            m_Canvas.SetActive(false);
            Destroy(m_CameraCanvas);
            Instantiate(m_Player, m_LRooms[0].transform.position + new Vector3(0, 3f, 2f), Quaternion.identity);
            Instantiate(m_Camera);

            done = true;
        }
        start = true;


    }

    void CreateRandomRoom()
    {

        // Create list for a room and randoms for how many cubes for x and z pos
        m_LRooms = new List<GameObject>();
        int planeRand = Random.Range(4, 10);
         
        for (int i = 0; i < planeRand; i++)
        {
            int randX = Random.Range(15, 25);
            int randZ = Random.Range(15, 25);
            m_CubePos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            m_LRooms.Add(Instantiate(m_Cubes, m_CubePos, Quaternion.identity)); // Create a new Cube and adds it to the list.
            Vector3 scale = new Vector3(randX, 2, randZ);
            m_LRooms[i].transform.localScale = scale;
            m_LRooms[i].transform.name = ("Hej " + i);
        }


    }
    void ConnectRoomsAlg()
    {
        m_LHalls = new List<GameObject>();
        GameObject a, b, c = null;
        float abDist, acDist = 0, bcDist = 0;
        bool skip;

        for (int i = 0; i < m_LRooms.Count; i++)
        {
            a = m_LRooms[i];
            for (int j = i + 1; j < m_LRooms.Count; j++)
            {
                skip = false;
                b = m_LRooms[j];
                abDist = Mathf.Pow(a.transform.position.x - b.transform.position.x, 2) + Mathf.Pow(a.transform.position.z - b.transform.position.z, 2);
                for (int k = 0; k < m_LRooms.Count; k++)
                {
                    if (k == i || k == j)
                        continue;
                    c = m_LRooms[k];
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
                    if (leftOrRight(a,b))
                    {
                        float distX = a.transform.position.x - b.transform.position.x;
                        GameObject cube = Instantiate(m_Hall_Cubes, a.transform.position, Quaternion.identity);                       
                        cube.transform.localScale = new Vector3(Mathf.Abs(distX), 0.1f, 5);
                        cube.transform.position += new Vector3((-distX / 2) - 1, 0.95f, 0);
                        m_LHalls.Add(cube);

                    }
                    else if (!leftOrRight(a, b))
                    {
                        float distX = b.transform.position.x - a.transform.position.x;
                        GameObject cube = Instantiate(m_Hall_Cubes, a.transform.position, Quaternion.identity);
                        cube.transform.localScale = new Vector3(Mathf.Abs(distX), 0.1f, 5);
                        cube.transform.position += new Vector3(Mathf.Abs(distX / 2) + 1 , 0.95f,0);
                        m_LHalls.Add(cube);
                    }
                    if (topOrBottom(a, b))
                    {
                        float distZ = a.transform.position.z - b.transform.position.z;
                        GameObject cube = Instantiate(m_Hall_Cubes, b.transform.position, Quaternion.identity);
                        cube.transform.localScale = new Vector3(5, 0.1f, Mathf.Abs(distZ));
                        cube.transform.position += new Vector3(0, 0.95f, (distZ / 2) + 1);
                        m_LHalls.Add(cube);

                    }
                     else if (!topOrBottom(a, b))
                    {
                        float distZ = b.transform.position.z - a.transform.position.z;
                        GameObject cube = Instantiate(m_Hall_Cubes, b.transform.position, Quaternion.identity);
                        cube.transform.localScale = new Vector3(5, 0.1f, Mathf.Abs(distZ));
                        cube.transform.position += new Vector3(0, 0.95f, (-distZ / 2) - 1);
                        m_LHalls.Add(cube);
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
    public void SeperationAlg(GameObject a, GameObject b)
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


       
        if (x > 20)
        {
            a.transform.position += new Vector3(dxa + 100, 0, dya + 100) * Time.deltaTime;
            b.transform.position += new Vector3(dxb, 0, dyb);
            x = 0;
        }
        else
        {
            a.transform.position += new Vector3(dxa, 0, dya);
            b.transform.position += new Vector3(dxb, 0, dyb);
            x++;
        }


    }

    public void Seperation(GameObject a,GameObject b)
    {
        SeperationAlg(a, b);
    }
    void Parrent()
    {
        GameObject pf = (GameObject)Instantiate(m_Room);

        foreach (GameObject a in m_LRooms)
        {

            a.transform.parent = pf.transform;

        }
        foreach (GameObject a in m_LHalls)
        {

            a.transform.parent = pf.transform;

        }


    }

 
    public List<GameObject> Rooms
    {
        get { return m_LRooms; }
       
    }

}
