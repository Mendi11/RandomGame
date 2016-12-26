using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float m_Speed;
    public float m_RotateSpeed;
    private Transform m_Target;
    private Rigidbody m_Rgb;
    public Vector3 m_Movment;

  
    // Use this for initialization
    void Start ()
    {
        m_Rgb = GetComponent<Rigidbody>();
        m_Target = GameObject.Find("Target").GetComponent<Transform>();
     
	}
    void FixedUpdate()
    {
        float m_MouseX = Input.GetAxis("Mouse X");
        float m_MouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(-m_MouseY, m_MouseX, 0) * Time.deltaTime * m_RotateSpeed);
        Vector3 moveDir = m_Target.position - transform.position;
        moveDir = moveDir.normalized;
        print(moveDir);
        if (Input.GetKey(KeyCode.W))
        {
            m_Rgb.velocity = new Vector3(Mathf.RoundToInt(moveDir.x), 0, Mathf.RoundToInt(moveDir.z)) * Time.deltaTime * m_Speed;

        }
        if (Input.GetKey(KeyCode.S))
        {
            m_Rgb.velocity = new Vector3(Mathf.RoundToInt(-moveDir.x), 0, Mathf.RoundToInt(-moveDir.z)) * Time.deltaTime * m_Speed;

        }
        if (Input.GetKey(KeyCode.A))
        {
            m_Rgb.velocity = new Vector3(Mathf.RoundToInt(-moveDir.z), 0, Mathf.RoundToInt(moveDir.x)) * Time.deltaTime * m_Speed;

        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Rgb.velocity = new Vector3(Mathf.RoundToInt(moveDir.z), 0, Mathf.RoundToInt(-moveDir.x)) * Time.deltaTime * m_Speed;

        }
        if (Input.GetKey(KeyCode.LeftShift)) // Sprint
        {
            m_Speed = 500;
        }
        else
        {
            m_Speed = 250;
        }

    }
    // Update is called once per frame
	void Update ()
    {
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
