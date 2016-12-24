using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float m_Speed;
    public float m_RotateSpeed;
    private Transform m_Target;
    private Rigidbody m_Rgb;
    private Collider col;

  
    // Use this for initialization
    void Start () {
        col = GetComponent<CapsuleCollider>();
        m_Rgb = GetComponent<Rigidbody>();
        m_Target = GameObject.Find("Target").GetComponent<Transform>();
       // transform.position += new Vector3(0, 2, 0);
	}
    void FixedUpdate()
    {
        float m_MouseX = Input.GetAxis("Mouse X");
        float m_MouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(-m_MouseY, m_MouseX, 0) * Time.deltaTime * m_RotateSpeed);
        Vector3 moveDir = m_Target.position - transform.position;
        moveDir = moveDir.normalized;

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
            m_Rgb.velocity = new Vector3(-1 * moveDir.z, 0, 0) * Time.deltaTime * m_Speed;

        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Rgb.velocity = new Vector3(1 * moveDir.z, 0, 0) * Time.deltaTime * m_Speed;

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
