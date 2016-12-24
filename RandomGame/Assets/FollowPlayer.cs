using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField]
    Transform m_Player;
    [SerializeField]
    Transform m_Target;
    public Vector3 m_OffsetCamera = new Vector3(1.5f,1f,-8f);
    private Vector3 velocity = Vector3.zero;
    private Vector3 m_CameraPos;
    public float timeDamp;


    // Use this for initialization
    void Start () {
		
	}


    void Update()
    {

        

    }

	// Update is called once per frame
	void LateUpdate ()
    {

       // m_OffsetCamera = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 4f, Vector3.up) * m_OffsetCamera;
        
        

        if(m_Target.transform.position.z > m_Player.transform.position.z)
            m_CameraPos = m_Player.transform.position + m_OffsetCamera;
        else if (m_Target.transform.position.z < m_Player.transform.position.z)
            m_CameraPos = m_Player.transform.position + new Vector3(1.5f, 1f, 8f);


        transform.position = Vector3.SmoothDamp(transform.position, m_CameraPos, ref velocity, timeDamp);
        transform.LookAt(m_Target.transform);



    }
}
