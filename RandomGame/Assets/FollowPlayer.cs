using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField]
    GameObject m_Target;
     Vector3 m_OffsetCamera = new Vector3(1.5f,-1f,-8f);
    private Vector3 velocity = Vector3.zero;
    public float timeDamp;


    // Use this for initialization
    void Start () {
		
	}


    void Update()
    {

        transform.position = m_Target.transform.position + m_OffsetCamera;

    }

	// Update is called once per frame
	void LateUpdate ()
    {
        transform.LookAt(m_Target.transform);
    
        //Vector3.SmoothDamp(transform.position, m_Target.transform.position, ref velocity, timeDamp);
   

    }
}
