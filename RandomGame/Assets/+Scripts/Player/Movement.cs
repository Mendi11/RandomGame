using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float m_Speed;
    public float m_RotateSpeed;

    private Transform m_Target;
    private Rigidbody m_Rgb;

    private Vector3 rotation = Vector3.zero;
    private float Sensitivity = 90f;
    // Use this for initialization
    void Start ()
    {
        m_Rgb = GetComponent<Rigidbody>();
        m_Target = GameObject.Find("Target").GetComponent<Transform>();
     
	}
    void FixedUpdate()
    {
        
       

    }
    // Update is called once per frame
	void Update ()
    {
        // Player rotation
        rotation += Vector3.up *  Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        rotation += Vector3.left * Input.GetAxis("Mouse Y")  * Sensitivity * Time.deltaTime; 
        transform.rotation = Quaternion.Euler(rotation);

        //transform.Rotate(new Vector3(-mouseY, mouseX, 0) * Time.deltaTime * m_RotateSpeed);//Rotate the player for inverted remove - on m_MouseY

        Vector3 moveDir = m_Target.position - transform.position; /// Get the direction the player should move
        moveDir = moveDir.normalized;



        //Movment
        if (Input.GetKey(KeyCode.W))
        {
            m_Rgb.velocity = new Vector3(moveDir.x, 0, moveDir.z) * Time.deltaTime * m_Speed;

        }
        if (Input.GetKey(KeyCode.S))
        {
            m_Rgb.velocity = new Vector3(-moveDir.x, 0, -moveDir.z) * Time.deltaTime * m_Speed;

        }
        if (Input.GetKey(KeyCode.A))
        {
            m_Rgb.velocity = new Vector3(-moveDir.z, 0, moveDir.x) * Time.deltaTime * m_Speed;

        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Rgb.velocity = new Vector3(moveDir.z, 0, -moveDir.x) * Time.deltaTime * m_Speed;

        }
        if (Input.GetKey(KeyCode.LeftShift)) // Sprint
        {
            m_Speed = 500;
        }
        else
        {
            m_Speed = 250;
        }



















        if (Input.GetKeyDown(KeyCode.C))// Lock mouse and makes it invisible
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Input.GetKeyDown(KeyCode.V))//Unlock and make visible
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }





    }
}
