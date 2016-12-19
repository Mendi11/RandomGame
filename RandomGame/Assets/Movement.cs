using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float m_Speed;
    // Use this for initialization
    void Start () {
        transform.position += new Vector3(0, 2, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 1) * m_Speed * Time.deltaTime;

        }
         if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -1) * m_Speed * Time.deltaTime;

        }
         if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * m_Speed * Time.deltaTime;

        }
         if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * m_Speed * Time.deltaTime;
        }
         


    }
}
