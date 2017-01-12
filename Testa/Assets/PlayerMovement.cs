using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D m_Rgb;
    private Vector2 m_moveDir;
    private float m_Speed;

    private bool m_grounded = false;
    private int m_Countgrounded = 0;

	// Use this for initialization
	void Start ()
    {
        m_Rgb = GetComponent<Rigidbody2D>();
        m_Speed = 100f;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        m_Rgb.MovePosition(m_moveDir * m_Speed);

    }
	void Update ()
    {
        float h = Input.GetAxis("Horizontal");
        float jump = 0;
        if (Input.GetButton("Jump"))
            jump = 5;

        m_moveDir += new Vector2(h, jump);
	}

    void OnCollisionEnter2D()
    {
        print("LOl");

    }




}
