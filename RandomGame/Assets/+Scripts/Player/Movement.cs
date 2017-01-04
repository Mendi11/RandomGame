using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float m_Speed;


    private Transform m_Target;
    private Rigidbody m_Rgb;
    private Vector3 m_moveAmount;
    private Vector3 m_Rotation = Vector3.zero;
    private float m_Sensitivity = 90f;
    // Use this for initialization
    void Start ()
    {
        m_Rgb = GetComponent<Rigidbody>();
        m_Target = GameObject.Find("Target").GetComponent<Transform>();
     
	}
    void FixedUpdate()
    {

        m_Rgb.MovePosition(m_Rgb.position + transform.TransformDirection( m_moveAmount) * m_Speed * Time.deltaTime);
        
    }
    // Update is called once per frame
	void Update ()
    {
        // Player rotation
        m_Rotation += Vector3.up *  Input.GetAxis("Mouse X") * m_Sensitivity * Time.deltaTime;
        m_Rotation += Vector3.left * Input.GetAxis("Mouse Y")  * m_Sensitivity * Time.deltaTime;
        m_Rotation.x = Mathf.Clamp(m_Rotation.x, -27f, 27f); // Clamp the rotation on up and down
        transform.rotation = Quaternion.Euler(m_Rotation);

        //transform.Rotate(new Vector3(-mouseY, mouseX, 0) * Time.deltaTime * m_RotateSpeed);//Rotate the player for inverted remove - on m_MouseY

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        m_moveAmount = moveDir;
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
