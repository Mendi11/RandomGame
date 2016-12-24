using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour {
    Vector3 offset;
    [SerializeField]
    Transform m_Player;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //offset = new Vector3(m_Player.position.x + 0f, m_Player.position.y + 0.5f, m_Player.position.z + 3f);

    }
    void LateUpdate()
    {
        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * Time.deltaTime, Vector3.right) * offset;
        //transform.position = offset;

    }
}
