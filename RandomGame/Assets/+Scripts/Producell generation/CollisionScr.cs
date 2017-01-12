using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScr : MonoBehaviour {


    private bool m_Collision = true;
    private int coll = 0;
    private int x = 10;
    public GameObject m_Wall;
    bool m_SetWalls = true;
    GameObject otherCube;
    GameObject hello;
    // Use this for initialization
    void Start ()
    {
        hello = GameObject.FindGameObjectWithTag("PG");
        otherCube = null; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
            if (coll > 0)
            {
                m_Collision = true;
            }
            else if (coll <= 0)
            {
                m_Collision = false;
            }

    }
    void Update()
    {
        print(this.gameObject + " " + coll);
        //if (hello.GetComponent<CreateRoom>().done == true && m_SetWalls)
        //{
        //    Walls();
        //    m_SetWalls = !m_SetWalls;
        //}
        while (m_Collision == true)
        {
            if (hello == null)
                continue;
            hello.GetComponent<CreateRoom>().Seperation(this.gameObject, otherCube);
            x -= 1;
            if (x < 0)
                break;
        }
    }

    void OnTriggerEnter(Collider col)
    {    
            if (col.gameObject.tag == "Room")
            {
                otherCube = col.gameObject;
                coll += 1;
            }
    }
    
    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == "Room")
        {
            coll -= 1;
        }


    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Halls")
        {
       

        }

    }
    //void Walls()
    //{
    //    float cornerX = this.transform.localScale.x / 2;
    //    float cornerZ = this.transform.localScale.z / 2;
    //    GameObject wall = Instantiate(m_Wall);
    //    if(this.transform.position.x < 0)
    //        wall.transform.position = new Vector3(this.transform.position.x - cornerX, 5.5f, this.transform.position.z);
    //    else
    //        wall.transform.position = new Vector3(this.transform.position.x + cornerX, 5.5f, this.transform.position.z);

    //    wall.transform.localScale = new Vector3(0.5f, 10, this.transform.localScale.z);
    //    GameObject wall2 = Instantiate(m_Wall);
    //    if (this.transform.position.z < 0)
    //        wall2.transform.position = new Vector3(this.transform.position.x, 5.5f, this.transform.position.z + cornerZ);
    //    else
    //        wall2.transform.position = new Vector3(this.transform.position.x, 5.5f, this.transform.position.z - cornerZ);

    //    wall2.transform.localScale = new Vector3(this.transform.localScale.x, 10, 0.5f);

    //    GameObject wall3 = Instantiate(m_Wall);
    //    if (this.transform.position.x < 0)
    //        wall3.transform.position = new Vector3(this.transform.position.x + cornerX, 5.5f, this.transform.position.z);
    //    else
    //        wall3.transform.position = new Vector3(this.transform.position.x - cornerX, 5.5f, this.transform.position.z);

    //    wall3.transform.localScale = new Vector3(0.5f, 10, this.transform.localScale.z);
    //    GameObject wall4 = Instantiate(m_Wall);
    //    if (this.transform.position.z < 0)
    //        wall4.transform.position = new Vector3(this.transform.position.x, 5.5f, this.transform.position.z - cornerZ);
    //    else
    //        wall4.transform.position = new Vector3(this.transform.position.x, 5.5f, this.transform.position.z + cornerZ);

    //    wall4.transform.localScale = new Vector3(this.transform.localScale.x, 10, 0.5f);
    //    //wall.transform.name = " Wall " + this.gameObject;    
    //    //print("GameObject: " + this.gameObject + "Wall: " + wall);
    //    //print("LocalX: " + this.transform.localScale.x + "PosX: " + this.transform.position.x);


    //}


    public int COll
    {
        get { return coll; }
        //set{ }
    }


    public bool CollisionRoom
    {
        get { return m_Collision; }
        //set{ }
    }
    public GameObject OtherCube
    {
        get { return otherCube; }
        //set{ }

    }


}
