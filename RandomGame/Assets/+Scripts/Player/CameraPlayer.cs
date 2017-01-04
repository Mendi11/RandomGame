using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour

{

    private Transform m_CamerFollow;
    private Transform m_Target;
    public float timeDamp;
    private Vector3 velocity = Vector3.zero;

    //private Vector3 m_CameraPos;
    //public float offsetX, offsetZ, offsetY;


    // Use this for initialization
    void Start ()
    {
        //Find the components in the world with the names
        m_CamerFollow = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Transform>();
        m_Target = GameObject.Find("Target").GetComponent<Transform>();


    }
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, m_CamerFollow.position, ref velocity, timeDamp); // Follows the gameobjebct behind the player

        //and moves smooth to it with a dampTime 
    }


    void Update()
    {

   

    }

	// Update is called once per frame
	void LateUpdate ()
    { 
        transform.LookAt(m_Target.transform); // Looks att the target infront of the player;
    }
}
