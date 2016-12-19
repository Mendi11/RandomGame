using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScr : MonoBehaviour {

    private bool m_Collision = true;
    private int coll = 0;
    private int x = 10;
    public bool m_Seperating = true;
    GameObject otherCube;
    public GameObject hello;
    // Use this for initialization
    void Start ()
    {
        otherCube = null; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    
            if (coll > 0)
            {
                m_Collision = true;
                hello.GetComponent<CreateRoom>().CollisionBool(m_Collision);
            }
            else if (coll <= 0)
            {
                m_Collision = false;
                hello.GetComponent<CreateRoom>().CollisionBool(m_Collision);
            }

        
 


    }
    void Update()
    {

        while (m_Collision == true)
        {
            hello.GetComponent<CreateRoom>().Collision(this.gameObject, otherCube);
            hello.GetComponent<CreateRoom>().CollisionBool(m_Collision);
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
